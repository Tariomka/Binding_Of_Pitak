using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using BoP.MapLibrary;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.Decorator;
using System.Diagnostics;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public static MapSettings settings = MapSettings.getInstance();

        public int mapWidth = settings.mapWidth;
        public int mapHeight = settings.mapHeight;
        public static int playerIndex = 0;
        public static Dictionary<string, int> players = new Dictionary<string, int>();
        public static Map gameMap = null;
        public static Director director = new Director();
        


        //public GameHub()
        //{
        //    //Example of decorated speed
        //    /*Creature hero = new Hero();
        //    hero.SetSpeed(10);
        //    Debug.WriteLine(hero.GetSpeed());
        //    Creature h2 = new ArmorBootsDecorator(hero);
        //    Debug.WriteLine(h2.GetSpeed());*/
        //    createMap();
        //}

        private Map GetMap()
        {
            if (gameMap == null)
            {
                MapBuilder builder = new MapBuilder();
                director.Builder = builder;
                director.BuildMixedMap();
                gameMap = builder.Build(MapSettings.HorizontalTiles, MapSettings.VerticalTiles);
                //gameMap = new MapBuilder()
                //    .AddTile(TileTypes.Grass)
                //    .AddTile(TileTypes.Lava)
                //    .Build(MapSettings.HorizontalTiles, MapSettings.VerticalTiles);
                Hero exHero = new Hero();
                exHero.AddItem(new Item());
                exHero.AddItem(new Item());
                exHero.AddItem(new Item());
                exHero.AddItem(new Item());
                Hero shallowHero = exHero.ShallowCopy();
                Hero deepHero = exHero.Clone();
                exHero.LoseItem();
                shallowHero.LoseItem();
                deepHero.LoseItem();
                Console.WriteLine(exHero.getItemCount());
                Console.WriteLine(shallowHero.getItemCount());
                Console.WriteLine(deepHero.getItemCount());

            }
            return gameMap;
        }

        #region Receive Messages

        public async Task JoinGame(Guid uid)
        {
            var playerid = uid.ToString();

            if (!players.ContainsKey(playerid))
            {
                playerIndex++;
                players.Add(playerid, playerIndex);
            }

            await SendGameJoinedMessage(players[playerid], players, this.GetMap());
            await SendPlayerJoinedMessage(players[playerid]);
        }

        public async Task SendCoordinates(int playerId, string direction)
        {
            await Clients.Others.SendAsync("ReceiveCoordinates", playerId, direction);
        }

        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
        }

        #endregion

        #region Send Messages

        public Task SendPlayerJoinedMessage(int id)
        {
            return Clients.Others.SendAsync("PlayerJoined", id);
        }

        public Task SendGameJoinedMessage(int id, Dictionary<string, int> playersInGame, Map map)
        {
            return Clients.Caller.SendAsync("GameJoined", id, playersInGame, map.frameTiles);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageTogroup(string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        }

        #endregion

    }
}
