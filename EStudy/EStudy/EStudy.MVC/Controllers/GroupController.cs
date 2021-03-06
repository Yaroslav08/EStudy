﻿using EStudy.Application;
using EStudy.Application.ViewModels.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("group")]
    [Authorize(Roles = "Admin")]
    public class GroupController : BaseController
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<GroupController> logger;
        public GroupController(ILogger<GroupController> _logger, IDataManager dataManager)
        {
            logger = _logger;
            this.dataManager = dataManager;
        }


        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllGroups()
        {
            return View(await dataManager.GroupService.GetAllGroups());
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string q, bool isReleased = false)
        {
            var groups = await dataManager.GroupService.Search(q, isReleased);
            return View("GetAllGroups", groups);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            var group = await dataManager.GroupService.GetGroupById(id);
            if (group == null)
            {
                ViewBag.Error = "Група не знайдено";
                return View("Error");
            }
            return View(group);
        }

        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetGroupMembers(int id)
        {
            return View(await dataManager.GroupService.GetGroupMembers(id));
        }


        [HttpGet("create")]
        public async Task<IActionResult> CreateGroup()
        {
            var req = await dataManager.GroupService.GetAllSpecialties();
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
            var result = await dataManager.GroupService.CreateGroup(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/group/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditGroup(int id)
        {
            var group = await dataManager.GroupService.GetForEdit(id);
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
            var result = await dataManager.GroupService.EditGroup(model);
            if (result == Constants.Constants.OK)
                return LocalRedirect("~/group/all");
            ModelState.AddModelError("", result);
            return View(model);
        }


        [HttpGet("{id}/addmember")]
        public async Task<IActionResult> AddMember(int id)
        {
            var students = await dataManager.UserService.GetAllStudents();
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
            var res = await dataManager.GroupService.AddUserToGroup(model);
            if (res == Constants.Constants.OK)
                return LocalRedirect($"~/group/{model.GroupId}");
            ModelState.AddModelError("", res);
            return View(model);
        }
    }
}
