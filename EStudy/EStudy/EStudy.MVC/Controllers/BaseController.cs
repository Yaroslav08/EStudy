using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    public class BaseController : Controller
    {
        public int GetId() => Convert.ToInt32(User.Identity.Name);
        public string GetRole() => User.Claims.FirstOrDefault(d => d.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
        public string GetFullName() => User.Claims.FirstOrDefault(d => d.Type == "Fullname").Value;
    }
}
