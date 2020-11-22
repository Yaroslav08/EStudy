using EStudy.Domain.Interfaces;
using EStudy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStudy.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<List<User>> GetAllAdmins()
        {
            return await db.Users.AsNoTracking()
                .Where(d => d.Role == Domain.Models.Enums.RoleType.Admin)
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50,
                    Role = d.Role
                })
                .ToListAsync();
        }

        public async Task<List<User>> GetNotConfirmedUsersAsync(int count, int skip)
        {
            return await db.Users
                .AsNoTracking()
                .Where(d => !d.IsConfirmed)
                .Select(d => new User
                {
                    Id = d.Id,
                    CreatedAt = d.CreatedAt,
                    FirstName = d.FirstName,
                    MiddleName = d.MiddleName,
                    LastName = d.LastName,
                    Login = d.Login,
                    CreatedFromIP = d.CreatedFromIP,
                    Role = d.Role
                })
                .Skip(skip).Take(count)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByEmail(string email)
        {
            return await db.Users.AsNoTracking()
                .Where(d => d.Email == email)
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50,
                    Role = d.Role
                })
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByPhone(string phone)
        {
            return await db.Users.AsNoTracking()
                .Where(d => d.Phone == phone)
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50,
                    Role = d.Role
                })
                .ToListAsync();
        }

        public async Task<List<User>> SearchAsync(string name, int count, int skip)
        {
            return await db.Users.AsNoTracking()
                .Where(d => d.FirstName.Contains(name) || d.LastName.Contains(name))
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50,
                    Role = d.Role
                })
                .Skip(skip).Take(count)
                .ToListAsync();
        }

        public async Task<List<User>> SearchStudentsAsync(string name, int count, int skip)
        {
            return await db.Users.AsNoTracking()
                .Where(d => (d.FirstName.Contains(name) || d.LastName.Contains(name)) && d.Role == Domain.Models.Enums.RoleType.Student)
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50,
                    Role = d.Role
                })
                .Skip(skip).Take(count)
                .ToListAsync();
        }

        public async Task<List<User>> SearchTeachersAsync(string name, int count, int skip)
        {
            return await db.Users.AsNoTracking()
                .Where(d => (d.FirstName.Contains(name) || d.LastName.Contains(name)) && d.Role == Domain.Models.Enums.RoleType.Teacher)
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50,
                    Role = d.Role
                })
                .Skip(skip).Take(count)
                .ToListAsync();
        }
    }
}