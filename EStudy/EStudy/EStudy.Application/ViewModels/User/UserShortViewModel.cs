using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.User
{
    public class UserShortViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname => FirstName + " " + LastName;
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }
}