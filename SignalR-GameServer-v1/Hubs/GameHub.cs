using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public static MapSettings settings = MapSettings.getInstance();

        public int MapWidth = settings.MapWidth;
        public int MapHight = settings.MapHight;
        public GameHub()
        {
        }

        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
        }

        public async Task SendCoordinates(string x, string y)
        {
            await Clients.Others.SendAsync("ReceiveCoordinates", x, y);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageTogroup(string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        }

        public async Task GetMapSize()
        {
            await Clients.All.SendAsync("ReceiveMapCoordinates", MapWidth, MapHight);
        }
    }
}
