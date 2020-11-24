using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.University;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("university")]
    public class UniversityController : Controller
    {
        private readonly IUniversityService universityService;
        private readonly ILogger<UniversityController> logger;
        public UniversityController(ILogger<UniversityController> _logger, IUniversityService _universityService)
        {
            logger = _logger;
            universityService = _universityService;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetUniversity()
        {
            return View(await universityService.GetUniversity());
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit()
        {
            var univ = await universityService.LoadForEdit();
            if (univ == null)
            {
                ViewBag.Error = Constants.Constants.UniversityNotFound;
                return View("Error");
            }
            return View(univ);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(UniversityEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await universityService.EditUniversity(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/university");
            ModelState.AddModelError("", result);
            return View(model);
        }
    }
}
