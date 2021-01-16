using EStudy.Application.ViewModels.Auth;
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
        Task<UserEditModel> GetForEditUser(int id);
        Task<string> EditUser(UserEditModel model);
        Task<List<UserShortViewModel>> SearchUsers(string name, int count, int skip, string param = null);
        Task<List<UserNotConfirmed>> GetNotConfirmedUsers(int count, int skip);
        Task<ConfirmResult> TryConfirmUser(ConfirmViewModel model);
        Task<ConfirmResult> ConfirmUser(ConfirmViewModel model);
        Task<RegisterResult> RegisterTeacher(RegisterViewModel model);
        Task<RegisterResult> RegisterStudent(RegisterViewModel model);
        Task<LoginResult> LoginUser(LoginViewModel model);
        Task<int> GetAllUsersCount();
        Task<bool> ValidTeacherCode(string code);
        Task<bool> ValidStudentCode(string code);
        Task<List<UserShortViewModel>> GetAllStudents();
        Task<List<UserShortViewModel>> GetAllTeachers();
        Task<string> ChangePassword(PasswordChangeViewModel model);
    }
}