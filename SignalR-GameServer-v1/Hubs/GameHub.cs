using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using BoP.MapLibrary;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.Decorator;
using System.Diagnostics;
using SignalR_GameServer_v1.Command;
using SignalR_GameServer_v1.MapLibrary;
using Map = BoP.MapLibrary.Map;

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

        private static CreatureController controller = new CreatureController();

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

            /*if (!players.ContainsKey(playerid))
            {
                playerIndex++;
                players.Add(playerid, playerIndex);
            }
            
            await SendGameJoinedMessage(players[playerid], players, this.GetMap());
            await SendPlayerJoinedMessage(players[playerid]);*/
            if(heroes.Find(x => x.GetId() == playerid) == null)
            {
                playerIndex++;
                heroes.Add( new Hero(playerid, playerIndex, 100, 1, 0, 480, 320));
            }

            heroesIdsAndNames.Add(heroes.Find(x => x.GetId() == playerid).GetId(), heroes.Find(x => x.GetId() == playerid).GetName());

            await SendGameJoinedMessage(heroes.Find(x => x.GetId() == playerid).GetName(), heroesIdsAndNames, this.GetMap());
            await SendPlayerJoinedMessage(heroes.Find(x => x.GetId() == playerid).GetName());
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
            string user = "Player " + hero.GetName();

            if (direction == "UNDO")
            {
                bool flag = controller.Undo();
                switch (flag)
                {
                    case false:
                        await SendMessage(user, "Undo Unsuccessful!");
                        break;
                    default:
                        await SendMessage(user, "Move Undone!");
                        break;
                }
            }
            else
            {
                ICommand movedir;
                switch (direction)
                {
                    case "LEFT":
                        movedir = new MoveLeftCommand(hero);
                        await SendMessage(user, "Move Left!");
                        break;
                    case "RIGHT":
                        movedir = new MoveRightCommand(hero);
                        await SendMessage(user, "Move Right!");
                        break;
                    case "UP":
                        movedir = new MoveUpCommand(hero);
                        await SendMessage(user, "Move Up!");
                        break;
                    case "DOWN":
                        movedir = new MoveDownCommand(hero);
                        await SendMessage(user, "Move Down!");
                        break;
                    default:
                        movedir = null;
                        await SendMessage(user, "Unsuccessful movement!");
                        break;
                }

                if (movedir != null)
                {
                    controller.Run(movedir);
                }
            }

            //hero.move(direction);
            await GetPlayerCoordinates(name);
        }

        public Task GetPlayerCoordinates(int name)
        {
            var hero = heroes.Find(x => x.GetName() == name);

            return Clients.All.SendAsync("PlayerNewCoordinates", name, hero.getPosX(), hero.GetPosY());
        }

        #endregion

    }
}
