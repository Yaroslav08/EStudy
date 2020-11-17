using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class Email : BaseModel<int>
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required, EmailAddress, MinLength(7), MaxLength(100)]
        public string Address { get; set; }
        [Required, MinLength(4), MaxLength(100)]
        public string Password { get; set; }
        [Required, MinLength(20), MaxLength(40)]
        public string Key { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}