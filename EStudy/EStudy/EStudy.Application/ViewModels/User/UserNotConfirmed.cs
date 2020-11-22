using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.User
{
    public class UserNotConfirmed
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string CreatedFromIP { get; set; }
        public string Role { get; set; }
    }
}