using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStudy.Application;

namespace EStudy.MVC.Controllers
{
    [Route("university")]
    [Authorize(Roles = "Admin")]
    public class UniversityController : Controller
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<UniversityController> logger;
        public UniversityController(ILogger<UniversityController> _logger, IDataManager dataManager)
        {
            logger = _logger;
            this.dataManager = dataManager;
        }


        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUniversity()
        {
            var res = await dataManager.UniversityService.GetUniversity();
            if (res == null)
                return LocalRedirect("~/university/create");
            return View(res);
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit()
        {
            var univ = await dataManager.UniversityService.LoadForEdit();
            if (univ == null)
            {
                ViewBag.Error = Constants.Constants.UniversityNotFound;
                return View("Error");
            }
            return View(univ);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UniversityEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await dataManager.UniversityService.EditUniversity(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/university");
            ModelState.AddModelError("", result);
            return View(model);
        }

        [HttpGet("create")]
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UniversityCreateModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await dataManager.UniversityService.CreateUniversity(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/university");
            ModelState.AddModelError("", result);
            return View(model);
        }
    }
}
