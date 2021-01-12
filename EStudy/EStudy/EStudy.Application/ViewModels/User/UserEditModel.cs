using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.User
{
    public class UserEditModel : RequestModel
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
        [MinLength(4), MaxLength(250)]
        public string Location { get; set; }
        [MinLength(10), MaxLength(250)]
        public string Avatar { get; set; }
        [MinLength(3), MaxLength(25), Phone]
        public string Phone { get; set; }
        [Required]
        public bool IsShowPhone { get; set; }
        [MinLength(5), MaxLength(100), EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool IsShowEmail { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string GitHub { get; set; }
        public string WebSite { get; set; }
    }
}