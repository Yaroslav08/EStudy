using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Specialty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("specialty")]
    [Authorize(Roles = "Admin")]
    public class SpecialtyController : Controller
    {
        private readonly ISpecialtyService specialtyService;
        private readonly ILogger<SpecialtyController> logger;
        public SpecialtyController(ILogger<SpecialtyController> _logger, ISpecialtyService _specialtyService)
        {
            logger = _logger;
            specialtyService = _specialtyService;
        }


        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSpecialties()
        {
            return View(await specialtyService.GetAllSpecialties());
        }


        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string q)
        {
            return View("GetAllSpecialties", await specialtyService.Search(q));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialty(int id)
        {
            var spec = await specialtyService.GetSpecialtyById(id);
            if (spec != null)
                return View(spec);
            ViewBag.Error = Constants.Constants.SpecialtyNotFound;
            return View("Error");
        }


        [HttpGet("create")]
        public async Task<IActionResult> CreateSpecialty()
        {
            var req = await specialtyService.GetAllDepartments();
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
            var result = await specialtyService.CreateSpecialty(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/specialty/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditSpecialty(int id)
        {
            var editSpec = await specialtyService.GetForEdit(id);
            if (editSpec == null)
            {
                ViewBag.Error = Constants.Constants.SpecialtyNotFound;
                return View("Error");
            }
            ViewBag.Departments = await specialtyService.GetAllDepartments();
            return View(editSpec);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecialty(SpecialtyEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await specialtyService.EditSpecialty(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/specialty/all");
            ModelState.AddModelError("", result);
            return View(model);
        }
    }
}
