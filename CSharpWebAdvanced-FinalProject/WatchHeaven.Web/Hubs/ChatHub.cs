using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WatchHeaven.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            if (Context.User?.Identity?.Name != null)
            {
                await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
            }
        }

        public async Task SendMessageToUser(string receiverUsername, string message)
        {
            if (Context.User?.Identity?.Name != null)
            {
                await Clients.User(receiverUsername).SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
            }
        }

        public override async Task OnConnectedAsync()
        {
            if (Context.User?.Identity?.Name != null)
            {
                await Clients.All.SendAsync("UserConnected", Context.User.Identity.Name);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User?.Identity?.Name != null)
            {
                await Clients.All.SendAsync("UserDisconnected", Context.User.Identity.Name);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
