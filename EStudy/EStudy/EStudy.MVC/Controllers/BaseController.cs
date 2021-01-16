using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace EStudy.MVC.Controllers
{
    public class BaseController : Controller
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
        public void ChangeClaim(string nameClaim, string newValue)
        {
            var claims = HttpContext.User.Identities.First();
            var claim = claims.Claims.FirstOrDefault(d => d.Type == nameClaim);
            if (claim != null)
            {
                claims.RemoveClaim(claim);
            }
            claims.AddClaim(new Claim(nameClaim, newValue));
        }
    }
}
