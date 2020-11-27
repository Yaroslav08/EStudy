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


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DepartmentCreateModel model)
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
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(DepartmentEditModel model)
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
