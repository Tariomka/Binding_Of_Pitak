using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using SignalR_GameServer_v1.MapLibrary;
using System;
using System.Collections.Generic;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public static MapSettings settings = MapSettings.getInstance();

        public int mapWidth = settings.mapWidth;
        public int mapHeight = settings.mapHeight;
        public static int playerIndex = 0;
        public static Dictionary<string, int> players = new Dictionary<string, int>();


        public List<Hero> heroList = new List<Hero>();

        public Map map;
        public GameHub()
        {
            //Example of decorated speed
            /*Creature hero = new Hero();
            hero.SetSpeed(10);
            Debug.WriteLine(hero.GetSpeed());
            Creature h2 = new ArmorBootsDecorator(hero);
            Debug.WriteLine(h2.GetSpeed());*/
            createMap();
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

            Hero newHero = new Hero();

            List<string> heroIds = new List<string>();

            heroList.ForEach(x => heroIds.Add(x.GetId()));

            if (!heroIds.Contains(playerid))
            {
                playerIndex++;
                newHero.SetName(playerIndex);
                newHero.SetId(playerid);
                heroList.Add(newHero);
            }

            //hero's name is the same thing as player index
            await SendNewIdReceived(newHero.GetName(), heroList);
            await PlayerJoined(newHero.GetName());

           


        }

        public Task SendNewIdReceived(int id, List<Hero> heroList)
        {
            return Clients.Caller.SendAsync("NewIdReceived", id, heroList);
        }

        public Task PlayerJoined(int id)
        {
            return Clients.Others.SendAsync("PlayerJoined", id);
        }


        //temp bybi dejau nx
        //--------------------------------------------------------------
        string[,] mapLayout;
        public async Task SendMapLayout(string[,] mapLayout)
        {
            await Clients.Others.SendAsync("ReceiveMapLayout", mapLayout);
        }
        private void createMap()
        {
            map = new Map(0);
            mapLayout = map.GetLayout();
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
            await Clients.All.SendAsync("ReceiveMapCoordinates", mapWidth, mapHeight);
        }
    }
}
