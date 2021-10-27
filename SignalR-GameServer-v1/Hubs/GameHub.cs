using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using SignalR_GameServer_v1.MapLibrary;
using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public static MapSettings Settings = MapSettings.getInstance();

        public int MapWidth = Settings.mapWidth;
        public int MapHeight = Settings.mapHeight;
        public static int PlayerIndex = 0;
        public static Dictionary<string, int> Players = new Dictionary<string, int>();
        public Map Map;
        public GameHub()
        {
            CreateMap();
        }

        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
        }

        public async Task SendCoordinates(int playerId, string direction)
        {
            await Clients.Others.SendAsync("ReceiveCoordinates", playerId, direction);
        }

        public async Task JoinGame(Guid uid)
        {
            var playerid = uid.ToString();

            if (!Players.ContainsKey(playerid))
            {
                PlayerIndex++;
                Players.Add(playerid, PlayerIndex);
            }

            await SendNewIdReceived(Players[playerid], Players);
            await PlayerJoined(Players[playerid]);
        }

        public Task SendNewIdReceived(int id, Dictionary<string, int> playersInGame)
        {
            return Clients.Caller.SendAsync("NewIdReceived", id, playersInGame);
        }

        public Task PlayerJoined(int id)
        {
            return Clients.Others.SendAsync("PlayerJoined", id);
        }


        //temp bybi dejau nx
        //--------------------------------------------------------------
        string[,] _mapLayout;
        public async Task SendMapLayout(string[,] mapLayout)
        {
            await Clients.Others.SendAsync("ReceiveMapLayout", mapLayout);
        }
        private void CreateMap()
        {
            Map = new Map(0);
            _mapLayout = Map.GetLayout();
            //int a = 5;
            //Random rnd = new Random();
            //for (int i = 0; i < width; i += 40)
            //{
            //    for (int j = 0; j < height; j += 40)
            //    {
            //        a++;
            //        Tile til = GetTile(rnd.Next(30));
            //        string pictureName = String.Concat("pictureBox", a);
            //        var picture = new PictureBox
            //        {
            //            Name = pictureName,
            //            Size = new Size(40, 40),
            //            Location = new Point(i, j),
            //            Image = Image.FromFile(til.image),
            //
            //        };
            //        this.Controls.Add(picture);
            //    }
            //}
            //this.picCanvas.SendToBack();
        }

        //---------------------------------------------------

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
            await Clients.All.SendAsync("ReceiveMapCoordinates", MapWidth, MapHeight);
        }
    }
}
