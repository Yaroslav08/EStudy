using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("department")]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly ILogger<DepartmentController> logger;
        public DepartmentController(ILogger<DepartmentController> _logger, IDepartmentService _departmentService)
        {
            logger = _logger;
            departmentService = _departmentService;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDepartments()
        {
            return View(await departmentService.GetDepartments());
        }


        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string q)
        {
            return View("GetAllDepartments", await departmentService.Search(q));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var depart = await departmentService.GetDepartmentById(id);
            if (depart != null)
                return View(depart);
            ViewBag.Error = Constants.Constants.DepartmentNotFound;
            return View("Error");
        }


        [HttpGet("create")]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDepartment(DepartmentCreateModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await departmentService.CreateDepartment(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/department/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditDepartment(int id)
        {
            var result = await departmentService.GetDepartmentForEdit(id);
            if (result == null)
            {
                ViewBag.Error = result;
                return View("Error");
            }
            return View(result);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDepartment(DepartmentEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await departmentService.EditDepartment(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/department/all");
            ModelState.AddModelError("", result);
            return View(model);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(int id)
        {
            return LocalRedirect("~/department/all");
        }
    }
}
