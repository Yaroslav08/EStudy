using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ім'я обовя'зково"), MinLength(3, ErrorMessage = "Мінімальна довжина 3 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Прізвище обовя'зково"), MinLength(3, ErrorMessage = "Мінімальна довжина 3 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Прізвище")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Логін обовя'зковий"), MinLength(5, ErrorMessage = "Мінімальна довжина 5 символів"), MaxLength(50, ErrorMessage = "Максимальна довжина 50 символів")]
        [DisplayName("Логін")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обовя'зковий"), MinLength(8, ErrorMessage = "Мінімальна довжина 8 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}