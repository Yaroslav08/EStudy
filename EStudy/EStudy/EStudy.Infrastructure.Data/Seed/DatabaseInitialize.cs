using EStudy.Domain.Models;
using EStudy.Infrastructure.Data.Context;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Infrastructure.Data.Seed
{
    public static class DatabaseInitialize
    {
        public static void SeedData(EStudyContext context)
        {
            context.Users.AddRangeAsync(new List<User>
            {
                new User
                {
                    FirstName = "Ярослав",
                    LastName = "Мудрик",
                    MiddleName = "Юрійович",
                    Login = "test01@gmail.com",
                    PasswordHash = "HKFVlsrh^foSJF@IDUFh%OISDfgpsdjfsdfioshgs#d",
                    CreatedAt = DateTime.Now,
                    IsConfirmed = true,
                    ConfirmedAt = DateTime.Now,
                    ConfirmedFromIP = "::1",
                    ConfirmCode = Generator.GetCode(80),
                    Born = new DateTime(2000, 3, 8),
                    Username = "Yaros08",
                    Role = Domain.Models.Enums.RoleType.Admin,
                    CreatedFromIP="::1",
                    Email = "test01@gmail.com",
                    Phone = "+380955555555"
                }
            });
            context.Universities.AddAsync(new University
            {

            });
            context.Departments.AddRangeAsync(new List<Department>()
            {
                new Department
                {
                    Name = ""
                }
            });

        }
    }
}