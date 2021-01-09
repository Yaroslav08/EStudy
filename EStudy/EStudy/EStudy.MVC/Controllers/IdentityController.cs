using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    public class IdentityController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
