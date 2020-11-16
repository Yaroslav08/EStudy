using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class ConfirmViewModel
    {
        [Required]
        public string Code { get; set; }
        public string IP { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}