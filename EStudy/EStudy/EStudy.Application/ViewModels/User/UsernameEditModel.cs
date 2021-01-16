using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.User
{
    public class UsernameEditModel : RequestModel
    {
        [MinLength(4), MaxLength(25)]
        [DisplayName("Нікнейм")]
        public string Username { get; set; }
    }
}