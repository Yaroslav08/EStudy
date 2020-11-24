using EStudy.Domain.Models;
using EStudy.Domain.Models.Enums;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Builders
{
    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetFirstname(string name)
        {
            user.FirstName = name;
            return this;
        }

        public UserBuilder SetMiddlename(string name)
        {
            user.MiddleName = name;
            return this;
        }

        public UserBuilder SetLastname(string name)
        {
            user.LastName = name;
            return this;
        }

        public UserBuilder SetLogin(string login)
        {
            user.Login = login;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.PasswordHash = password;
            return this;
        }

        public UserBuilder SetConfirmCode(string code)
        {
            user.ConfirmCode = code;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}