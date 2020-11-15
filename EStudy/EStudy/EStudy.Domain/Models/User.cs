using EStudy.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EStudy.Domain.Models
{
    public class User : BaseModel<int>
    {
        [Required, MinLength(3), MaxLength(25)]
        public string FirstName { get; set; }
        [MinLength(3), MaxLength(30)]
        public string MiddleName { get; set; }
        [Required, MinLength(3), MaxLength(25)]
        public string LastName { get; set; }
        [MinLength(4), MaxLength(25)]
        public string Username { get; set; }
        [MinLength(5), MaxLength(500)]
        public string About { get; set; }
        [MinLength(10), MaxLength(250)]
        public string Avatar50 { get; set; }
        [MinLength(10), MaxLength(250)]
        public string Avatar { get; set; }
        [Required, MinLength(7), MaxLength(50)]
        public string Login { get; set; }
        [Required, MinLength(20), MaxLength(2500)]
        public string PasswordHash { get; set; }
        [Required]
        public RoleType Role { get; set; } = RoleType.Student;
        [MinLength(2), MaxLength(50)]
        public string RoleString { get; set; }
    }
}