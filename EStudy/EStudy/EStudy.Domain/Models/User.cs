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
        public string Firstname { get; set; }
        [MinLength(3), MaxLength(30)]
        public string Middlename { get; set; }
        [Required, MinLength(3), MaxLength(25)]
        public string Lastname { get; set; }
        [MinLength(4), MaxLength(25)]
        public string Username { get; set; }
        [Required, MinLength(7), MaxLength(50)]
        public string Login { get; set; }
        [Required, MinLength(20), MaxLength(2500)]
        public string PasswordHash { get; set; }
        [Required]
        public RoleType Role { get; set; } = RoleType.Student;
    }
}