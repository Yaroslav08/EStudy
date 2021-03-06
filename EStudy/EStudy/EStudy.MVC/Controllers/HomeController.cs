﻿using EStudy.Application;
using EStudy.Application.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
            if (user == null)
                return LocalRedirect("~/identity/logout");
            return View(user);
        }



        [HttpGet("{name}")]
        public async Task<IActionResult> GetUser(string name)
        {
            if (name.StartsWith("@"))
            {
                string username = name.Split("@").Last();
                if (username == GetUsername())
                    return LocalRedirect("~/me");
                var user = await dataManager.UserService.GetUserByUsername(username);
                return View(user);
            }
            if (name.StartsWith("id"))
            {
                int id = Convert.ToInt32(name.Split("id").Last());
                if (GetId() == id)
                    return LocalRedirect("~/me");
                var user = await dataManager.UserService.GetUserById(id);
                return View(user);
            }
            return LocalRedirect("~/");
        }



        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            var req = HttpContext.Request.Headers["Referer"].ToString();
            var encode = WebUtility.UrlEncode(query);
            if (query.Length <= 2)
                return Redirect(req);
            if (req.Contains("/department/"))
                return LocalRedirect($"~/department/search?q={encode}");
            if (req.Contains("/specialty/"))
                return LocalRedirect($"~/specialty/search?q={encode}");
            if (req.Contains("/group/"))
                return LocalRedirect($"~/group/search?q={encode}");
            else
                return LocalRedirect($"~/");
        }
    }
}