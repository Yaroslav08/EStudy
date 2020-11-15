using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class ConfirmViewModel
    {
        public string Code { get; set; }
        public string IP { get; set; }
        public int UserId { get; set; }
    }
}