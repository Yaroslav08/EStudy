﻿using EStudy.Application;
using EStudy.Application.ViewModels.Auth;
using EStudy.Application.ViewModels.User;
using EStudy.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
                return View("ConfirmSuccess");
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

        [HttpPost("identity/confirm")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmUser(ConfirmViewModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _dataManager.UserService.ConfirmUser(model);
            if (result.Successed)
                return View("ConfirmSuccess");
            ModelState.AddModelError("", result.Error);
            return View(model);
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


        [HttpPost("identity/edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditProfile(UserEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = GetId();
            var result = await _dataManager.UserService.EditUser(model);
            if (result != Constants.Constants.OK)
            {
                ModelState.AddModelError("", result);
                return View(model);
            }
            return LocalRedirect("/me");
        }



        [HttpPost("identity/password")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(PasswordChangeViewModel model)
        {
            model.UserId = GetId();
            var res = await _dataManager.UserService.ChangePassword(model);
            if (res != Constants.Constants.OK)
            {
                ModelState.AddModelError("", res);
                return View(model);
            }
            return LocalRedirect("~/identity/logout");
        }


        [HttpPost("identity/username")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsername(UsernameEditModel model)
        {
            model.UserId = GetId();
            model.IP = GetIP();
            var res = await _dataManager.UserService.EditUsername(model);
            if (res != Constants.Constants.OK)
            {
                ModelState.AddModelError("", res);
                return PartialView("_EditUsername", model);
            }
            ChangeClaim("Username", model.Username);
            return LocalRedirect("~/me");
        }


        [HttpGet("identity/setting")]
        [Authorize]
        public async Task<IActionResult> Setting()
        {
            var setting = await _dataManager.UserService.GetUserSetting(GetId());
            setting.Username = new UsernameEditModel
            {
                Username = GetUsername()
            };
            return View(setting);
        }


        [HttpGet("identity/logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Identity");
        }
    }
}
