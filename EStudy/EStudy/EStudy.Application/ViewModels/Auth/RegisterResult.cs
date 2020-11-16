using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class RegisterResult
    {
        public bool Successed { get; set; } = true;
        public bool IsError
        {
            get
            {
                if (Error != null)
                {
                    Successed = false;
                    return true;
                }
                else
                    return false;
            }
        }
        public string Error { get; set; } = null;
        public object Object { get; set; }
    }
}