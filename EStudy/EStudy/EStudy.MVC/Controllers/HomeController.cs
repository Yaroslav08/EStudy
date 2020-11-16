using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace EStudy.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly ILogger<HomeController> logger;
        public HomeController(ILogger<HomeController> _logger, IUserService _userService)
        {
            logger = _logger;
            userService = _userService;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var res = await userService.RegisterUser(model);
            if (res.Successed)
            {
                ViewBag.Data = res.Object;
                return View("RegisterSuccess");
            }
            ModelState.AddModelError("", res.Error);
            return View(model);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> Confirm([FromQuery]ConfirmViewModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await userService.ConfirmUser(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/login");
            ViewBag.Error = result;
            return View("Error");
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await userService.LoginUser(model);
            if(result.Successed)
            {
                await Authenticate(result.User);
                if (string.IsNullOrEmpty(model.ReturnUrl))
                    return LocalRedirect("~/");
                return LocalRedirect(model.ReturnUrl);
            }
            ModelState.AddModelError("", result.Error);
            return View(model);
        }




        private async Task Authenticate(Domain.Models.User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim("Fullname", user.FirstName + " " + user.LastName)
            };
            if (!string.IsNullOrEmpty(user.Username))
                claims.Add(new Claim("Username", user.Username));
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}