using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStudy.Application.ViewModels.Auth
{
    public class PasswordChangeViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Пароль обов'язковий"), MinLength(8, ErrorMessage = "Мінімальна довжина 8 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Старий пароль")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Пароль обов'язковий"), MinLength(8, ErrorMessage = "Мінімальна довжина 8 символів"), MaxLength(25, ErrorMessage = "Максимальна довжина 25 символів")]
        [DisplayName("Новий пароль")]
        public string NewPassword { get; set; }
    }
}
