using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required, MinLength(5), MaxLength(50)]
        public string Login { get; set; }
        [Required, MinLength(8), MaxLength(25)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}