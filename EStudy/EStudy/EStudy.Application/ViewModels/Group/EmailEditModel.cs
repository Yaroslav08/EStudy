using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Group
{
    public class EmailEditModel : RequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required, EmailAddress, MinLength(7), MaxLength(100)]
        public string Address { get; set; }
        [Required, MinLength(4), MaxLength(100)]
        public string Password { get; set; }
        public int GroupId { get; set; }
    }
}