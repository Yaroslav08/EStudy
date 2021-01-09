using EStudy.Application;
using EStudy.Application.ViewModels.Auth;
using EStudy.Domain.Models;
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
    public class IdentityController : BaseController
    {
        private ILogger<IdentityController> _logger;
        private IDataManager _dataManager;

        public IdentityController(ILogger<IdentityController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }

        [HttpGet("identity/register")]
        public IActionResult Register(string type)
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            ViewBag.Type = type;
            return View();
        }

        [HttpPost("identity/register")]
        public async Task<IActionResult> Register([FromQuery] string type, RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Перевірте правильність введених даних");
                return View(model);
            }
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            var res = type switch
            {
                "s" => await RegisterStudent(model),
                "t" => await RegisterTeacher(model),
                _ => new RegisterResult { Successed = false, Error = "Оберіть тип користувача" }
            };
            if (res.Successed)
            {
                return View("RegisterSuccess");
            }
            ModelState.AddModelError("", res.Error);
            return View(model);
        }

        private async Task<RegisterResult> RegisterStudent(RegisterViewModel model)
        {
            if(!await _dataManager.UserService.ValidStudentCode(model.Code))
            {
                return new RegisterResult
                {
                    Successed = false,
                    Error = "Код студента не валідний"
                };
            }
            return await _dataManager.UserService.RegisterStudent(model);
        }

        private async Task<RegisterResult> RegisterTeacher(RegisterViewModel model)
        {
            if (!await _dataManager.UserService.ValidTeacherCode(model.Code))
            {
                return new RegisterResult
                {
                    Successed = false,
                    Error = "Код викладача не валідний"
                };
            }
            return await _dataManager.UserService.RegisterTeacher(model);
        }

        [HttpGet("identity/confirm")]
        public async Task<IActionResult> TryConfirmUser(string code, int userId)
        {
            var res = await _dataManager.UserService.TryConfirmUser(new ConfirmViewModel
            {
                Code = code,
                UserId = userId,
                IP = HttpContext.Connection.RemoteIpAddress.ToString()
            });
            if (res.Successed)
                return LocalRedirect("ConfirmSuccess"); //ToDo "redirect to true page"
            if (!res.NeedGroupCode)
            {
                ViewBag.Error = "Some error";
                return View("Error");
            }
            return View(new ConfirmViewModel
            {
                Code = code,
                UserId = userId
            });
        }








        [HttpGet("identity/login")]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("/");
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost("identity/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Перевірте правильність введених даних");
                return View(model);
            }
            var result = await _dataManager.UserService.LoginUser(model);
            if (result.Successed)
            {
                Console.WriteLine(result.Successed.ToString());
                await Authenticate(result.User);
                if (string.IsNullOrEmpty(model.ReturnUrl))
                    return LocalRedirect("~/");
                return LocalRedirect(model.ReturnUrl);
            }
            ModelState.AddModelError("", result.Error);
            return View(model);
        }

        private async Task Authenticate(User user)
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

        [HttpGet("identity/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Identity");
        }
    }
}
