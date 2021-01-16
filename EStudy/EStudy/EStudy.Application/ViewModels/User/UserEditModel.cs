using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.User
{
    public class UserEditModel : RequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(25)]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; }
        [MinLength(3), MaxLength(30)]
        [DisplayName("По-батькові")]
        public string MiddleName { get; set; }
        [Required, MinLength(3), MaxLength(25)]
        [DisplayName("Прізвище")]
        public string LastName { get; set; }
        [Required, Range(0, 3)]
        [DisplayName("Стать")]
        public int GenderValue { get; set; }
        [MinLength(5), MaxLength(500)]
        [DisplayName("Про себе")]
        public string About { get; set; }
        [DisplayName("Дата народження")]
        [DataType(DataType.Date)]
        public DateTime? Born { get; set; }
        [MinLength(4), MaxLength(250)]
        [DisplayName("Ваше місцезнаходження (або місто народження)")]
        public string Location { get; set; }
        [MinLength(10), MaxLength(250)]
        [DisplayName("Посилання на аватарку")]
        public string Avatar { get; set; }
        [MinLength(3), MaxLength(25), Phone]
        [DisplayName("Телефон")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Інші користувачі можуть бачити телефон")]
        public bool IsShowPhone { get; set; }
        [MinLength(5), MaxLength(100), EmailAddress]
        [DisplayName("Електронна пошта")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Інші користувачі можуть бачити пошту")]
        public bool IsShowEmail { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string GitHub { get; set; }
        public string WebSite { get; set; }
    }
}