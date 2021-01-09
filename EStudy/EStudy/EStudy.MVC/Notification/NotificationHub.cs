using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EStudy.MVC.Notification
{
    public class NotificationHub : Hub
    {
        public async Task SendToAll(string message)
        {
            await Clients.All.SendAsync("Notify", message);
        }
    }
}