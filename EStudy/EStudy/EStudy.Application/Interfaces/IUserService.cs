﻿using EStudy.Application.ViewModels.Auth;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserById(int id);
        Task<List<UserShortViewModel>> SearchUsers(string name, int count, int skip, string param = null);
        Task<List<UserNotConfirmed>> GetNotConfirmedUsers(int count, int skip);
        Task<string> ConfirmUser(ConfirmViewModel model);
        Task<RegisterResult> RegisterUser(RegisterViewModel model);
        Task<LoginResult> LoginUser(LoginViewModel model);
        Task<int> GetCountUsers();
    }
}