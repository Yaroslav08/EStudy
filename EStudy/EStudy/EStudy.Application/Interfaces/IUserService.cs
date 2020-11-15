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
        Task<string> ConfirmUser(ConfirmViewModel model);
    }
}