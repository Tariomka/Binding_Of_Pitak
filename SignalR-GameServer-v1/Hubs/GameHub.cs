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
        public static List<Hero> heroes = new List<Hero>();
        public static Map gameMap = null;
        public static Dictionary<string, int> heroesIdsAndNames = new Dictionary<string, int>();

        //public gamehub()
        //{
        //    //example of decorated speed
        //    /*creature hero = new hero();
        //    hero.setspeed(10);
        //    debug.writeline(hero.getspeed());
        //    creature h2 = new armorbootsdecorator(hero);
        //    debug.writeline(h2.getspeed());*/
        //    createmap();
        //}

        private Map GetMap()
        {
            if (gameMap == null)
            {
                gameMap = new MapBuilder()
                    .AddTile(TileTypes.Grass)
                    .AddTile(TileTypes.Lava)
                    .Build(MapSettings.HorizontalTiles, MapSettings.VerticalTiles);
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

            //due to decorator changes
            //await SendGameJoinedMessage(players[playerid], players, this.GetMap());
            //await SendPlayerJoinedMessage(players[playerid]);

            var newHero = new Hero(playerid, playerIndex, 100, 1, 0, 480, 320);
            heroes.Add(newHero);

            heroesIdsAndNames.Add(newHero.GetId(), newHero.GetName());

            await SendGameJoinedMessage(heroes.Find(x => x.GetId() == playerid).GetName(), heroesIdsAndNames, this.GetMap());
            await SendPlayerJoinedMessage(newHero.GetName());
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
            return Clients.Caller.SendAsync("GameJoined", id, playersInGame, map.Tiles);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageTogroup(string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        }

        public async Task MovePlayer(int name, string direction)
        {
            var hero = heroes.Find(x => x.GetName() == name);
            hero.move(direction);
            await GetPlayerCoordinates(name);
        }

        public Task GetPlayerCoordinates(int name)
        {
            var hero = heroes.Find(x => x.GetName() == name);

            return Clients.Caller.SendAsync("PlayerNewCoordinates", name, hero.getPosX(), hero.GetPosY());
        }

        #endregion

    }
}
