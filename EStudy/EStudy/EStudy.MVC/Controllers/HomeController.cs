using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EStudy.Application;

namespace EStudy.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<HomeController> logger;

        public HomeController(IDataManager dataManager, ILogger<HomeController> logger)
        {
            this.dataManager = dataManager;
            this.logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var user = await dataManager.UserService.GetUserById(Convert.ToInt32(User.Identity.Name));
            return View(user);
        }

        [HttpGet("confirm")]
        public IActionResult Confirm(string code)
        {
            return View();
        }


        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm([FromQuery] string code, ConfirmViewModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await dataManager.UserService.ConfirmUser(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/login");
            ModelState.AddModelError("", result);
            return View();
        }



        [HttpGet("search")]
        public IActionResult Search([FromQuery]string query)
        {
            var req = HttpContext.Request.Headers["Referer"].ToString();
            if (query.Length <= 2)
                return Redirect(req);
            if (req.Contains("/department/"))
                return LocalRedirect($"~/department/search?q={query}");
            if (req.Contains("/specialty/"))
                return LocalRedirect($"~/specialty/search?q={query}");
            if (req.Contains("/group/"))
                return LocalRedirect($"~/group/search?q={query}");
            else
                return LocalRedirect($"~/");
        }
    }
}