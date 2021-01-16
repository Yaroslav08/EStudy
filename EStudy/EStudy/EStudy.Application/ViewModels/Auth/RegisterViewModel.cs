using EStudy.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class RegisterViewModel : RequestModel
    {
        [Required(ErrorMessage = "Ім'я обов'язково"), MinLength(3, ErrorMessage = "Мінімальна довжина 3 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Прізвище обов'язково"), MinLength(3, ErrorMessage = "Мінімальна довжина 3 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Прізвище")]
        public string LastName { get; set; }
        [Required, Range(0,3)]
        [DisplayName("Стать")]
        public int GenderValue { get; set; }
        [Required(ErrorMessage = "Логін обов'язковий"), MinLength(5, ErrorMessage = "Мінімальна довжина 5 символів"), MaxLength(50, ErrorMessage = "Максимальна довжина 50 символів")]
        [DisplayName("Логін")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обов'язковий"), MinLength(8, ErrorMessage = "Мінімальна довжина 8 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Код обов'язковий"), MinLength(15), MaxLength(20)]
        public string Code { get; set; }
    }

    public enum TypeUser
    {
        Student,
        Teacher
    }
}