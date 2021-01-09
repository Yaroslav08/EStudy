using EStudy.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EStudy.MVC.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        private readonly IDataManager dataManager;
        private readonly ILogger<UserController> logger;
        public UserController(ILogger<UserController> _logger, IDataManager dataManager)
        {
            logger = _logger;
            this.dataManager = dataManager;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            if (Id <= 0)
            {
                ViewBag.Error = Constants.Constants.NotFound;
                return View("Error");
            }
            if (Convert.ToInt32(Id) == Convert.ToInt32(User.Identity.Name))
                return LocalRedirect("~/me");
            return View(await dataManager.UserService.GetUserById(Convert.ToInt32(Id)));
        }
    }
}