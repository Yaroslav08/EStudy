using EStudy.Application;
using EStudy.Application.ViewModels.Specialty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("specialty")]
    [Authorize(Roles = "Admin")]
    public class SpecialtyController : BaseController
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<SpecialtyController> logger;
        public SpecialtyController(ILogger<SpecialtyController> _logger, IDataManager dataManager)
        {
            logger = _logger;
            this.dataManager = dataManager;
        }


        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSpecialties()
        {
            return View(await dataManager.SpecialtyService.GetAllSpecialties());
        }


        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string q)
        {
            return View("GetAllSpecialties", await dataManager.SpecialtyService.Search(q));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialty(int id)
        {
            var spec = await dataManager.SpecialtyService.GetSpecialtyById(id);
            if (spec != null)
                return View(spec);
            ViewBag.Error = Constants.Constants.SpecialtyNotFound;
            return View("Error");
        }


        [HttpGet("create")]
        public async Task<IActionResult> CreateSpecialty()
        {
            var req = await dataManager.SpecialtyService.GetAllDepartments();
            if (req == null || req.Count == 0)
                return LocalRedirect("~/department/create");
            ViewBag.Departments = req;
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecialty(SpecialtyCreateModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await dataManager.SpecialtyService.CreateSpecialty(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/specialty/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditSpecialty(int id)
        {
            var editSpec = await dataManager.SpecialtyService.GetForEdit(id);
            if (editSpec == null)
            {
                ViewBag.Error = Constants.Constants.SpecialtyNotFound;
                return View("Error");
            }
            ViewBag.Departments = await dataManager.SpecialtyService.GetAllDepartments();
            return View(editSpec);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecialty(SpecialtyEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await dataManager.SpecialtyService.EditSpecialty(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/specialty/all");
            ModelState.AddModelError("", result);
            return View(model);
        }
    }
}
