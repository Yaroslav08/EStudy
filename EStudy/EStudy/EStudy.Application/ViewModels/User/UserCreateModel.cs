using EStudy.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.User
{
    public class UserCreateModel : RequestModel
    {
        [Required, MinLength(3), MaxLength(25)]
        public string FirstName { get; set; }
        [MinLength(3), MaxLength(30)]
        public string MiddleName { get; set; }
        [Required, MinLength(3), MaxLength(25)]
        public string LastName { get; set; }
        [Required, MinLength(7), MaxLength(50)]
        public string Login { get; set; }
        [Required, MinLength(20), MaxLength(2500)]
        public string PasswordHash { get; set; }
        [Required, MinLength(25), MaxLength(50)]
        public string CodeForConnect { get; set; }
    }
}