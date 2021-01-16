using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EStudy.MVC.Notification
{
    public class NotificationHub : Hub
    {
        private int onlineUsers = 0;
        public async Task SendToAll(string message)
        {
            await Clients.All.SendAsync("Notify", message);
        }

        public override async Task OnConnectedAsync()
        {
            onlineUsers++;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            onlineUsers--;
            await base.OnDisconnectedAsync(exception);
        }

        public int OnlineUsers => onlineUsers;
    }
}