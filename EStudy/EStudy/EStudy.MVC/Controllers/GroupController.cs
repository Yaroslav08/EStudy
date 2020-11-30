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
        private readonly IUserService userService;
        private readonly ILogger<GroupController> logger;
        public GroupController(ILogger<GroupController> _logger, IGroupService _groupService, IUserService _userService)
        {
            logger = _logger;
            groupService = _groupService;
            userService = _userService;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            var group = await groupService.GetGroupById(id);
            return View(group);
        }

        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetGroupMembers(int id)
        {
            //var members = await groupService.GetGroupMembers(id);
            return View(await groupService.GetGroupMembers(id));
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


        [HttpGet("{id}/addmember")]
        public async Task<IActionResult> AddMember(int id)
        {
            var students = await userService.GetAllStudents();
            if(students==null || students.Count==0)
            {
                ModelState.AddModelError("","Не знайдено жодного студента");
                return View(new GroupMemberModel
                {
                    GroupId = id
                });
            }
            ViewBag.Students = students;
            return View(new GroupMemberModel
            {
                GroupId = id
            });
        }

        [HttpPost("addmember")]
        public async Task<IActionResult> AddMember(GroupMemberModel model)
        {
            var res = await groupService.AddUserToGroup(model);
            if (res == Constants.Constants.OK)
                return LocalRedirect($"~/group/{model.GroupId}");
            ModelState.AddModelError("", res);
            return View(model);
        }
    }
}
