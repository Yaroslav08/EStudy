using AutoMapper;
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

        public async Task<string> ConfirmUser(ConfirmViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.ConfirmCode == model.Code);
            if (user == null) return Constants.Constants.TokenNotValid;
            if (user.IsConfirmed) return Constants.Constants.AlreadyConfirmed;
            if (user.CodeValidUntil < DateTime.Now) return Constants.Constants.TokenExpired;
            user.IsConfirmed = true;
            user.ConfirmedAt = DateTime.Now;
            user.ConfirmedFromIP = model.IP;
            if(user.Role!=RoleType.Student)
            {
                return await unitOfWork.UserRepository.UpdateAsync(user);
            }
            var group = await unitOfWork.GroupRepository.GetByWhereAsync(d => d.CodeForConnect == model.GroupCode);
            if (group == null) return Constants.Constants.GroupByCodeNotFound;
            var groupMember = new GroupMember
            {
                UserId = user.Id,
                GroupId = group.Id,
                MemberRole = GroupMemberRole.Student,
                CreatedFromIP = model.IP,
                CreatedByUserId = model.UserId,
                Title = "Студент"
            };
            await unitOfWork.UserRepository.UpdateAsync(user);
            return await unitOfWork.GroupMemberRepository.CreateAsync(groupMember);

        }

        public async Task<RegisterResult> RegisterUser(RegisterViewModel model)
        {
            if (await unitOfWork.UserRepository.IsExistAsync(d => d.Login == model.Login))
                return new RegisterResult { Successed = false, Error = Constants.Constants.LoginBusy };

            var user = new UserBuilder()
                .SetFirstname(model.FirstName)
                .SetLastname(model.LastName)
                .SetLogin(model.Login)
                .SetPassword(PasswordManager.GeneratePasswordHash(model.Password))
                .SetConfirmCode(Generator.GetString(30))
                .Build();

            if(await unitOfWork.UserRepository.CountAsync() == 0)
            {
                user.Role = RoleType.Admin;
                user.IsConfirmed = true;
                user.ConfirmedFromIP = model.IP;
                user.ConfirmedAt = DateTime.Now;
                var resultAdminReg = await unitOfWork.UserRepository.CreateAsync(user);
                if (resultAdminReg == Constants.Constants.OK)
                    return new RegisterResult { Successed = true };
                return new RegisterResult { Successed = false, Error = resultAdminReg };
            }

            user.Role = model.TypeUser switch
            {
                TypeUser.Student => RoleType.Student,
                TypeUser.Teacher => RoleType.Teacher,
                _ => RoleType.Admin
            };

            var result = await unitOfWork.UserRepository.CreateAsync(user);
            if (result == Constants.Constants.OK)
                return new RegisterResult { Successed = true };

            return new RegisterResult { Successed = false, Error = result };
        }

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
    }
}