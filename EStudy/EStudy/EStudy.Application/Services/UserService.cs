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
            var user = await unitOfWork.UserRepository.GetByWhereAsTrackingAsync(d => d.Id == model.UserId);
            if (user == null) return Constants.Constants.UserNotFoundById;
            if (user.IsConfirmed) return Constants.Constants.AlreadyConfirmed;
            if (user.ConfirmCode != model.Code) return Constants.Constants.TokenNotValid;
            if (user.CodeValidUntil < DateTime.Now) return Constants.Constants.TokenExpired;
            user.IsConfirmed = true;
            user.ConfirmedFromIP = model.IP;
            user.ConfirmedAt = DateTime.Now;
            return await unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<RegisterResult> RegisterUser(RegisterViewModel model)
        {
            if (await unitOfWork.UserRepository.IsExistAsync(d => d.Login == model.Login))
                return new RegisterResult { Error = Constants.Constants.LoginBusy, Successed = false };
            var user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Login = model.Login;
            user.PasswordHash = PasswordManager.GeneratePasswordHash(model.Password);
            user.Role = Domain.Models.Enums.RoleType.Student;
            user.ConfirmCode = Generator.GetString(new Random().Next(51, 99));
            var res = await unitOfWork.UserRepository.CreateAsync(user);
            if (res != Constants.Constants.OK)
                return new RegisterResult { Error = res, Successed = false };
            //ToDo send to user email confirm
            return new RegisterResult() { Successed = true, Confirm = new ConfirmDataModel { Code = user.ConfirmCode, UserId = user.Id } };
        }

        public async Task<LoginResult> LoginUser(LoginViewModel model)
        {
            var user = await unitOfWork.UserRepository.GetByWhereAsync(d => d.Login == model.Login);
            if (user == null)
                return new LoginResult { Error = Constants.Constants.UserNotExist };
            if (!PasswordManager.VerifyPasswordHash(model.Password, user.PasswordHash))
                return new LoginResult { Error = Constants.Constants.PasswordNotComapre };
            if (!user.IsConfirmed)
                return new LoginResult { Error = Constants.Constants.NotConfirmed };
            return new LoginResult { User = user };
        }

        public async Task<int> GetCountUsers()
        {
            return await unitOfWork.UserRepository.CountAsync();
        }
    }
}