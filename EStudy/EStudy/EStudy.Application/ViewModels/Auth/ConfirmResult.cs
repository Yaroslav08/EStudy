using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class ConfirmResult
    {
        public bool Successed { get; set; } = true;
        public string Error { get; set; } = null;
        public bool IsError => !string.IsNullOrEmpty(Error);
        public bool NeedGroupCode { get; set; } = true;
    }
}