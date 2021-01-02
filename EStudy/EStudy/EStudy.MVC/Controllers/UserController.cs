using EStudy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EStudy.Application;

namespace EStudy.MVC.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<UserController> logger;
        public UserController(ILogger<UserController> _logger, IDataManager dataManager)
        {
            logger = _logger;
            this.dataManager = dataManager;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            if (Id <= 0)
            {
                ViewBag.Error = Constants.Constants.NotFound;
                return View("Error");
            }
            if (Convert.ToInt32(Id) == Convert.ToInt32(User.Identity.Name))
                return LocalRedirect("~/me");
            return View(await dataManager.UserService.GetUserById(Convert.ToInt32(Id)));
        }
    }
}