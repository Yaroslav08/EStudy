using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class SettingViewModel
    {
        public UserEditModel User { get; set; }
        public PasswordChangeViewModel Password { get; set; }
        public UsernameEditModel Username { get; set; }
    }
}