﻿using AutoMapper;
using EStudy.Infrastructure.Data;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EStudy.Application.ViewModels.Auth;
using Extensions;
using EStudy.Domain.Models;
using EStudy.Application.Builders;
using EStudy.Domain.Models.Enums;
using EStudy.Constants;

namespace EStudy.Application.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            return mapper.Map<UserViewModel>(await unitOfWork.UserRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<UserShortViewModel>> SearchUsers(string name, int count, int skip, string param = null) =>
             param switch
             {
                 "s" => mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.SearchStudentsAsync(name, count, skip)),
                 "t" => mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.SearchTeachersAsync(name, count, skip)),
                 _ => mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.SearchAsync(name, count, skip))
             };

        public async Task<LoginResult> LoginUser(LoginViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsync(d => d.Login == model.Login);
            if (user == null)
                return new LoginResult { Error = Constants.Constants.UserNotExist, Successed = false };
            if (!user.IsConfirmed)
                return new LoginResult { Error = Constants.Constants.NotConfirmed, Successed = false };
            if (!PasswordManager.VerifyPasswordHash(model.Password, user.PasswordHash))
                return new LoginResult { Error = Constants.Constants.PasswordNotComapre, Successed = false };
            return new LoginResult { User = user, Successed = true };
        }

        public async Task<int> GetAllUsersCount()
        {
            return await unitOfWork.UserRepository.CountAsync();
        }

        public async Task<List<UserNotConfirmed>> GetNotConfirmedUsers(int count, int skip)
        {
            return mapper.Map<List<UserNotConfirmed>>(await unitOfWork.UserRepository.GetNotConfirmedUsersAsync(count, skip));
        }

        public async Task<bool> ValidTeacherCode(string code)
        {
            return await unitOfWork.UniversityRepository.ValidTeacherCodeConnectAsync(code);
        }

        public async Task<bool> ValidStudentCode(string code)
        {
            return await unitOfWork.UniversityRepository.ValidStudentCodeConnectAsync(code);
        }

        public async Task<List<UserShortViewModel>> GetAllStudents()
        {
            return mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.GetListByWhereAsync(d => d.Role == RoleType.Student));
        }

        public async Task<List<UserShortViewModel>> GetAllTeachers()
        {
            return mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.GetListByWhereAsync(d => d.Role == RoleType.Teacher));
        }

        public async Task<RegisterResult> RegisterTeacher(RegisterViewModel model)
        {
            if (await unitOfWork.UserRepository.IsExistAsync(d => d.Login == model.Login))
                return new RegisterResult { Successed = false, Error = Constants.Constants.LoginBusy };

            var user = new UserBuilder()
                .SetFirstname(model.FirstName)
                .SetLastname(model.LastName)
                .SetLogin(model.Login)
                .SetPassword(PasswordManager.GeneratePasswordHash(model.Password))
                .SetConfirmCode(Generator.GetString(30))
                .SetRole(RoleType.Teacher)
                .Build();
            user.Gender = model.GenderValue switch
            {
                0 => GenderType.Female,
                1 => GenderType.Male,
                2 => GenderType.Other,
                _ => GenderType.Other
            };
            var result = await unitOfWork.UserRepository.CreateAsync(user);
            if (result == Constants.Constants.OK)
            {
                //ToDo send to email confirm
                return new RegisterResult { Successed = true };
            }

            return new RegisterResult { Successed = false, Error = result };
        }

        public async Task<RegisterResult> RegisterStudent(RegisterViewModel model)
        {
            if (await unitOfWork.UserRepository.IsExistAsync(d => d.Login == model.Login))
                return new RegisterResult { Successed = false, Error = Constants.Constants.LoginBusy };

            var user = new UserBuilder()
                .SetFirstname(model.FirstName)
                .SetLastname(model.LastName)
                .SetLogin(model.Login)
                .SetPassword(PasswordManager.GeneratePasswordHash(model.Password))
                .SetConfirmCode(Generator.GetString(30))
                .SetRole(RoleType.Student)
                .Build();
            user.Gender = model.GenderValue switch
            {
                0 => GenderType.Female,
                1 => GenderType.Male,
                2 => GenderType.Other,
                _ => GenderType.Other
            };
            var result = await unitOfWork.UserRepository.CreateAsync(user);
            if (result == Constants.Constants.OK)
            {
                //ToDo send to email confirm
                return new RegisterResult { Successed = true };
            }

            return new RegisterResult { Successed = false, Error = result };
        }

        public async Task<ConfirmResult> TryConfirmUser(ConfirmViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Id == model.UserId);
            if (user.IsConfirmed)
                return new ConfirmResult { Successed = false, Error = "Користувач вже підтверджений", NeedGroupCode = false };
            if(user.Role != RoleType.Teacher)
            {
                return new ConfirmResult { Successed = false, NeedGroupCode = true };
            }
            if (user.CodeValidUntil < DateTime.Now)
            {
                return new ConfirmResult { Successed = false, NeedGroupCode = false, Error = "Час життя коду вичерпано" };
            }
            if (user.ConfirmCode != model.Code)
            {
                return new ConfirmResult { Successed = false, NeedGroupCode = false, Error = "Код не є валдіним" };
            }
            user.IsConfirmed = true;
            user.ConfirmedAt = DateTime.Now;
            user.ConfirmedFromIP = model.IP;
            var save = await unitOfWork.UserRepository.UpdateAsync(user);

            return save == Constants.Constants.OK ?
                new ConfirmResult { Successed = true, NeedGroupCode = false } :
                new ConfirmResult { Successed = false, NeedGroupCode = false, Error = save };
        }

        public async Task<ConfirmResult> ConfirmUser(ConfirmViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Id == model.UserId);
            if (user.IsConfirmed)
                return new ConfirmResult { Successed = false, Error = "Користувач вже підтверджений", NeedGroupCode = false };

            if (user.Role != RoleType.Student)
            {
                return new ConfirmResult { Successed = false, NeedGroupCode = false, Error = "Ви не студент" };
            }

            if (user.CodeValidUntil > DateTime.Now)
            {
                return new ConfirmResult { Successed = false, NeedGroupCode = false, Error = "Час життя коду вичерпано" };
            }
            if (user.ConfirmCode != model.Code)
            {
                return new ConfirmResult { Successed = false, NeedGroupCode = false, Error = "Код не є валдіним" };
            }
            user.IsConfirmed = true;
            user.ConfirmedAt = DateTime.Now;
            user.ConfirmedFromIP = model.IP;
            var save = await unitOfWork.UserRepository.UpdateAsync(user);


            var group = await unitOfWork.GroupRepository.GetByWhereAsync(d => d.CodeForConnect == model.GroupCode);
            if (group == null) return new ConfirmResult { Successed = false, NeedGroupCode = false, Error = "Код групи не валідний" };
            var member = new GroupMember
            {
                UserId = model.UserId,
                GroupId = group.Id,
                MemberRole = GroupMemberRole.Student,
                Title = "Студент",
                CreatedFromIP = model.IP,
                CreatedByUserId = model.UserId
            };
            var groupMemberResult = await unitOfWork.GroupMemberRepository.CreateAsync(member);
            return groupMemberResult == Constants.Constants.OK ?
                new ConfirmResult { Successed = true, NeedGroupCode = false } :
                new ConfirmResult { Successed = false, NeedGroupCode = false, Error = groupMemberResult };

            
        }

        public async Task<UserEditModel> GetForEditUser(int id)
        {
            return mapper.Map<UserEditModel>(await unitOfWork.UserRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<string> EditUser(UserEditModel model)
        {
            if (!SocialLinksValidate.IsValidUrl(model.Twitter, "https://twitter.com", "https://www.twitter.com"))
                return Constants.Constants.TwitterLinkBroken;
            if (!SocialLinksValidate.IsValidUrl(model.Facebook, "https://facebook.com", "https://www.facebook.com"))
                return Constants.Constants.FacebookLinkBroken;
            if (!SocialLinksValidate.IsValidUrl(model.Instagram, "https://instagram.com", "https://www.instagram.com"))
                return Constants.Constants.InstagramLinkBroken;
            if (!SocialLinksValidate.IsValidUrl(model.GitHub, "https://github.com", "https://www.github.com"))
                return Constants.Constants.GitHubLinkBroken;
            var userFromDb = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (userFromDb == null)
                return Constants.Constants.UserNotFoundById;
            var user = mapper.Map<UserEditModel, User>(model, userFromDb);
            user.Gender = model.GenderValue switch
            {
                0 => GenderType.Female,
                1 => GenderType.Male,
                2 => GenderType.Other,
                _ => GenderType.Other
            };
            return await unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<string> ChangePassword(PasswordChangeViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Id == model.UserId);
            if (user == null)
                return Constants.Constants.UserNotExist;
            if (!user.IsConfirmed)
                return Constants.Constants.NotConfirmed;
            if (!PasswordManager.VerifyPasswordHash(model.OldPassword, user.PasswordHash))
                return Constants.Constants.PasswordNotComapre;
            user.PasswordHash = PasswordManager.GeneratePasswordHash(model.NewPassword);
            return await unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<SettingViewModel> GetUserSetting(int userId)
        {
            var user = await GetForEditUser(userId);
            if (user == null)
                return null;
            return new SettingViewModel
            {
                User = user
            };
        }

        public async Task<string> EditUsername(UsernameEditModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Id == model.UserId);
            if (user == null)
                return Constants.Constants.UserNotFoundById;
            if (model.Username == user.Username)
                return Constants.Constants.OK;
            var res = await unitOfWork.UserRepository.IsExistUsernameAsync(model.Username);
            if (res.Item2 != model.UserId && res.Item1)
                return Constants.Constants.UsernameExist;
            user.Username = model.Username;
            user.IsEdit = true;
            user.DateLastEdit = DateTime.Now;
            user.EditedFromIP = model.IP;
            user.EditedByUserId = model.UserId;
            return await unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<UserViewModel> GetUserByUsername(string name)
        {
            return mapper.Map<UserViewModel>(await unitOfWork.UserRepository.GetByWhereAsync(d => d.Username == name));
        }

        public async Task<string> ChangeEmail(EmailChangeViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Login == model.OldEmail);
            if (user == null)
                return Constants.Constants.UserNotExist;
            var res = await unitOfWork.UserRepository.IsExistLoginAsync(model.NewEmail);
            if (user.Id == res.Item2)
                return Constants.Constants.OK;
            if(res.Item1)
                return Constants.Constants.LoginBusy;
            user.IsConfirmed = false;
            user.ConfirmCode = Generator.GetString(30);
            user.ConfirmedFromIP = null;
            user.ConfirmedAt = null;
            user.Login = model.NewEmail;
            var updated = await unitOfWork.UserRepository.UpdateAsync(user);
            if (updated == Constants.Constants.OK)
            {
                //ToDo send to email confirm
                return Constants.Constants.OK;
            }
            return Constants.Constants.Error;
        }
    }
}