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
        public DateTime? Born { get; set; }
        public int? Age { get; set; }
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
        [MinLength(3), MaxLength(25), Phone]
        public string Phone { get; set; }
        [Required]
        public bool IsShowPhone { get; set; } = true;
        [MinLength(5), MaxLength(100), EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool IsShowEmail { get; set; } = true;

        [Required]
        public bool IsConfirmed { get; set; } = false;
        [Required, MinLength(50), MaxLength(100)]
        public string ConfirmCode { get; set; }
        public DateTime CodeValidUntil { get; set; } = DateTime.Now.AddDays(1);
        public DateTime? ConfirmedAt { get; set; }
        [MinLength(3), MaxLength(50)]
        public string ConfirmedFromIP { get; set; }
        public List<GroupMember> GroupMembers { get; set; }
        public List<Course> Courses { get; set; }
    }
}