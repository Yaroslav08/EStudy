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

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var user = await userService.GetUserById(Convert.ToInt32(User.Identity.Name));
            return View(user);
        }


        [HttpGet("register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            return View();
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (model.TypeUser == TypeUser.Student && !await userService.ValidStudentCode(model.Code))
            {
                ModelState.AddModelError("", Constants.Constants.StudentCodeNotValid);
                return View();
            }
            if (model.TypeUser == TypeUser.Teacher && !await userService.ValidTeacherCode(model.Code))
            {
                ModelState.AddModelError("", Constants.Constants.TeacherCodeNotValid);
                return View();
            }

            var res = await userService.RegisterUser(model);
            if (res.Successed)
            {
                return View("RegisterSuccess");
            }
            ModelState.AddModelError("", res.Error);
            return View(model);
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
            var result = await userService.ConfirmUser(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/login");
            ModelState.AddModelError("", result);
            return View();
        }


        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
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


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }
    }
}