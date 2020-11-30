using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("group")]
    [Authorize(Roles = "Admin")]
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;
        private readonly ILogger<GroupController> logger;
        public GroupController(ILogger<GroupController> _logger, IGroupService _groupService)
        {
            logger = _logger;
            groupService = _groupService;
        }


        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllGroups()
        {
            return View(await groupService.GetAllGroups());
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string q, bool? IsReleased, int count = 50, int skip = 2)
        {
            return View("GetAllGroups", await groupService.Search(q, count, skip, IsReleased));
        }


        [HttpGet("create")]
        public async Task<IActionResult> CreateGroup()
        {
            var req = await groupService.GetAllSpecialties();
            if (req == null || req.Count == 0)
                return LocalRedirect("~/specialty/create");
            ViewBag.Spec = req;
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroup(GroupCreateModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await groupService.CreateGroup(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/group/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditGroup(int id)
        {
            var group = await groupService.GetForEdit(id);
            if (group != null)
                return View(group);
            ViewBag.Error = Constants.Constants.GroupNotFound;
            return View("Error");
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditGroup(GroupEditModel model)
        {
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserId = Convert.ToInt32(User.Identity.Name);
            var result = await groupService.EditGroup(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/group/all");
            ModelState.AddModelError("", result);
            return View(model);
        }
    }
}
