using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class LoginResult : RegisterResult
    {
        public Domain.Models.User User { get; set; }
    }
}