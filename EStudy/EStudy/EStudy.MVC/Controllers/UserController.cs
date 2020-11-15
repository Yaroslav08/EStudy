using EStudy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;
        public UserController(ILogger<UserController> _logger, IUserService _userService)
        {
            logger = _logger;
            userService = _userService;
        }

        [HttpGet("{Id?}")]
        public async Task<IActionResult> GetUser(int? Id)
        {
            if (Id == null)
            {
                ViewBag.Error = Constants.Constants.NotFound;
                return View("Error");
            }
            return View(await userService.GetUserById(Convert.ToInt32(Id)));
        }
    }
}