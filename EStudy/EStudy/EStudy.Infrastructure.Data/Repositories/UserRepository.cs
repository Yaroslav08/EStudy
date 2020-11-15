﻿using EStudy.Domain.Interfaces;
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
        public async Task<List<User>> SearchAsync(string name, int count, int skip)
        {
            return await db.Users.AsNoTracking()
                .Where(d => d.FirstName.Contains(name) || d.LastName.Contains(name))
                .Select(d => new User
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.Username,
                    Avatar50 = d.Avatar50
                })
                .Skip(skip).Take(count)
                .ToListAsync();
        }
    }
}