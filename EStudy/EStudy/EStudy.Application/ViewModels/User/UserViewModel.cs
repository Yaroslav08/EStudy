using EStudy.Domain.Models;
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
        public GenderType Gender { get; set; }
        public string Username { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public DateTime? Born { get; set; }
        public string Avatar50 { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string GitHub { get; set; }
        public string WebSite { get; set; }

        public bool IsHaveAnySocialNetworks()
        {
            if (string.IsNullOrWhiteSpace(Twitter) &&
                string.IsNullOrWhiteSpace(Instagram) &&
                string.IsNullOrWhiteSpace(Facebook) &&
                string.IsNullOrWhiteSpace(GitHub) &&
                string.IsNullOrWhiteSpace(WebSite))
            {
                return false;
            }
            return true;
        }

    }
}