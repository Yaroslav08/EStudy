using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string About { get; set; }
        public string Avatar50 { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}