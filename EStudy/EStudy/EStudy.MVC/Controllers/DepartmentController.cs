using EStudy.Application;
using EStudy.Application.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("department")]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : BaseController
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<DepartmentController> logger;
        public DepartmentController(ILogger<DepartmentController> _logger, IDataManager dataManager)
        {
            logger = _logger;
            this.dataManager = dataManager;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDepartments()
        {
            return View(await dataManager.DepartmentService.GetDepartments());
        }


        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string q)
        {
            return View("GetAllDepartments", await dataManager.DepartmentService.Search(q));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var depart = await dataManager.DepartmentService.GetDepartmentById(id);
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
            var result = await dataManager.DepartmentService.CreateDepartment(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/department/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditDepartment(int id)
        {
            var result = await dataManager.DepartmentService.GetDepartmentForEdit(id);
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
            var result = await dataManager.DepartmentService.EditDepartment(model);
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
