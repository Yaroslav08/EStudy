using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EStudy.MVC.Notification
{
    public class NotificationHub : Hub
    {
        [Authorize(Roles = "Admin")]
        public async Task Notify(string message)
        {
            await Clients.All.SendAsync("Notify", message);
        }
    }
}