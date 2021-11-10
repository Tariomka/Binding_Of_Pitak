using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using BoP.MapLibrary;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.Decorator;
using System.Diagnostics;
using System.Linq;
using SignalR_GameServer_v1.Command;
using SignalR_GameServer_v1.MapLibrary;
using SignalR_GameServer_v1.Observer;
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
        private static CreatureController controller = new CreatureController();
        private static Subject server = new Server();
        public static Director director = new Director();

        private Map GetMap()
        {
            if (gameMap == null)
            {
                MapBuilder builder = new MapBuilder();
                director.Builder = builder;
                director.BuildMixedMap();
                gameMap = builder.Build(MapSettings.HorizontalTiles, MapSettings.VerticalTiles);
            }
            return gameMap;
        }

        #region Receive Messages

        public async Task JoinGame(Guid uid)
        {
            var playerid = uid.ToString();

            if(!players.ContainsKey(playerid))
            {
                playerIndex++;
                players.Add(playerid, playerIndex);

                var newPlayer = new Hero(playerIndex, "Player", 100, 1, 0, 480, 320);
                if (playerIndex == 1)
                {
                    heroes.Add(newPlayer);
                    server.attach(newPlayer);
                }
                else if (playerIndex % 3 == 0)
                {
                    Hero decoratedHero = new ArmorBootsDecorator(newPlayer);
                    heroes.Add(decoratedHero);
                    server.attach(decoratedHero);
                }
                else if (playerIndex % 3 == 1)
                {
                    Hero decoratedHero = new ArmorBootsDecorator(newPlayer);
                    Hero decoratedHero2 = new ArmorGlovesDecorator(decoratedHero);
                    heroes.Add(decoratedHero2);
                    server.attach(decoratedHero2);
                }
                else
                {
                    Hero decoratedHero = new ArmorBootsDecorator(newPlayer);
                    Hero decoratedHero2 = new ArmorGlovesDecorator(decoratedHero);
                    Hero decoratedHero3 = new ArmorLegsDecorator(decoratedHero2);
                    heroes.Add(decoratedHero3);
                    server.attach(decoratedHero3);
                }
                
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
            await Clients.All.SendAsync("ReceiveMessage", user, message);
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

        public async Task MovePlayer(int id, string direction)
        {
            var hero = heroes.Find(x => x.GetId() == id);
            string user = "Player " + hero.GetId();

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
                    case "ATTACK":
                        movedir = new AttackCommand(hero);
                        await SendMessage(user, "Attack!");
                        break;
                    case "ENDTURN":
                        movedir = new EndTurnCommand(hero);
                        await SendMessage(user, "End Turn!");
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

            await GetPlayerCoordinates(id);
        }

        public Task GetPlayerCoordinates(int id)
        {
            var hero = heroes.Find(x => x.GetId() == id);

            return Clients.All.SendAsync("PlayerNewCoordinates", id, hero.GetPosX(), hero.GetPosY());
        }

        #endregion

    }
}
