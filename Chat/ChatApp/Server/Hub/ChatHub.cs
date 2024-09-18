using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat
{
    public class ChatHub : Hub
    {
        public async Task SendMessage (string username, string message)
        {
            await Clients.All.SendAsync("SendMessage", username, message);
        }
    }
}
