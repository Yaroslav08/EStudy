using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStudy.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> SearchAsync(string name, int count, int skip);
        Task<List<User>> SearchStudentsAsync(string name, int count, int skip);
        Task<List<User>> SearchTeachersAsync(string name, int count, int skip);
        Task<List<User>> GetUsersByEmail(string email);
        Task<List<User>> GetUsersByPhone(string phone);
        Task<List<User>> GetAllAdmins();
    }
}