using EStudy.Application;
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
    public class IdentityController : BaseController
    {
        private ILogger<IdentityController> _logger;
        private IDataManager _dataManager;

        public IdentityController(ILogger<IdentityController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
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
