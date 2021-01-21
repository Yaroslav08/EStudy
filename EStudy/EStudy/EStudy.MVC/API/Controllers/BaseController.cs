using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace EStudy.MVC.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int GetId() => Convert.ToInt32(User.Identity.Name);
        public string GetIP() => HttpContext.Connection.RemoteIpAddress.ToString();
        public string GetRole() => User.Claims.FirstOrDefault(d => d.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
        public string GetFullName() => User.Claims.FirstOrDefault(d => d.Type == "Fullname").Value;
        public string GetUsername()
        {
            var claims = User.Identities.First();
            var claim = claims.Claims.FirstOrDefault(d => d.Type == "Username");
            if (claim == null)
                return "";
            return claim.Value;
        }
    }
}