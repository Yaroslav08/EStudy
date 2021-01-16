using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Логін обовя'зковий"), MinLength(5, ErrorMessage = "Мінімальна довжина 5 символів"), MaxLength(50, ErrorMessage = "Максимальна довжина 50 символів")]
        [DisplayName("Логін")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обовя'зковий"), MinLength(8, ErrorMessage = "Мінімальна довжина 8 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}