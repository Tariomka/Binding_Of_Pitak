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
using Item = SignalR_GameServer_v1.Characters.Item;
using SignalR_GameServer_v1.Iterators;
using SignalR_GameServer_v1.States;
using SignalR_GameServer_v1.ChainOfResponsibility;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public static MapSettings settings = MapSettings.getInstance();

        public int mapWidth = settings.mapWidth;
        public int mapHeight = settings.mapHeight;
        public static int playerIndex = 0;
        public static Dictionary<string, int> players = new Dictionary<string, int>();
        public static CreaturesCollection heroes = new CreaturesCollection();
        public static Map gameMap = null;
        private static CreatureController controller = new CreatureController();
        private static Subject server = new Server();
        public static Director director = new Director();

        AbstractLogger loggerChain = GetChainOfLoggers();
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
                //Hero exHero = new Hero();
                //exHero.AddItem(new Item());
                //exHero.AddItem(new Item());
                //exHero.AddItem(new Item());
                //exHero.AddItem(new Item());
                //Hero shallowHero = exHero.ShallowCopy();
                //Hero deepHero = exHero.Clone();
                //exHero.LoseItem();
                //shallowHero.LoseItem();
                //deepHero.LoseItem();
                //Console.WriteLine(exHero.getItemCount());
                //Console.WriteLine(shallowHero.getItemCount());
                //Console.WriteLine(deepHero.getItemCount());
            }
            return gameMap;
        }

        #region Receive Messages

        public async Task JoinGame(Guid uid)
        {
            var id = uid.ToString();
            var playerid = Context.ConnectionId;

            if(!players.ContainsKey(playerid))
            {
                playerIndex++;
                players.Add(playerid, playerIndex);

                var newPlayer = new Hero(playerIndex, "Player", 100, 5, 0, 480, 320);
                server.attach(newPlayer);
                heroes.Add(newPlayer);

                if (playerIndex == 1)
                {
                    heroes.GetCreature(0).TransitionTo(new ReadyState());
                    await SendStateToCaller();
                }
                //else if (playerIndex % 3 == 0)
                //{
                //    Hero decoratedHero = new ArmorBootsDecorator(newPlayer);
                //    heroes.Add(decoratedHero);
                //    server.attach(decoratedHero);
                //}
                //else if (playerIndex % 3 == 1)
                //{
                //    Hero decoratedHero = new ArmorBootsDecorator(newPlayer);
                //    Hero decoratedHero2 = new ArmorGlovesDecorator(decoratedHero);
                //    heroes.Add(decoratedHero2);
                //    server.attach(decoratedHero2);
                //}
                //else
                //{
                //    Hero decoratedHero = new ArmorBootsDecorator(newPlayer);
                //    Hero decoratedHero2 = new ArmorGlovesDecorator(decoratedHero);
                //    Hero decoratedHero3 = new ArmorLegsDecorator(decoratedHero2);
                //    heroes.Add(decoratedHero3);
                //    server.attach(decoratedHero3);
                //}

            }
            loggerChain.LogMessage(AbstractLogger.INFO, "new player id is: " + playerid);
            await SendGameJoinedMessage(players[playerid], players, this.GetMap());
            await SendPlayerJoinedMessage(players[playerid]);
        }

        public async Task SendCoordinates(int playerId, string direction)
        {
            try
            {
                await Clients.Others.SendAsync("ReceiveCoordinates", playerId, direction);
            }
            catch(Exception e)
            {
                loggerChain.LogMessage(AbstractLogger.ERROR, "Error in SendCoordinates method: " + e);
            }
        }

        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            try
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);

            }
            catch (Exception e)
            {
                loggerChain.LogMessage(AbstractLogger.ERROR, "Error in SendMessage method: " + e);
            }
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
        }
        public async Task SendGlobalMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveGlobalMessage", message);
        }

        #endregion

        #region Send Messages

        public Task SendPlayerJoinedMessage(int id)
        {
            return Clients.Others.SendAsync("PlayerJoined", id);
        }

        public Task SendGameJoinedMessage(int id, Dictionary<string, int> playersInGame, Map map)
        {
            return Clients.Caller.SendAsync("GameJoined", id, playersInGame, map.frameTiles, map.frameItems);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendStateToCaller()
        {
            return Clients.Caller.SendAsync("SwitchState");
        }

        public Task SendStateToSpecificClient(string id)
        {
            return Clients.Client(id).SendAsync("SwitchState");
        }

        public Task SendMessageTogroup(string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        }

        public async Task MovePlayer(int id, string direction)
        {
            var hero = heroes.Find(id);
            string user = "Player " + hero.GetId();

            ICommand movedir = null;
            if (hero.GetRemainingSpeed() > 0)
            {
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
                    default:
                        await SendMessage(user, "Unsuccessful movement!");
                        break;
                }
            }
            else
            {
                await SendMessage(user, "No Speed Remaining!");
            }

            if (movedir != null)
            {
                controller.Run(movedir);
            }

            await GetPlayerCoordinates(id);
        }

        public async Task EndPlayerTurn(int id)
        {
            var hero = heroes.Find(id);
            string user = "Player " + hero.GetId();

            var command = new EndTurnCommand(hero);
            await SendMessage(user, "End Turn!");
            controller.Run(command);
            await SendStateToCaller();

            var nextHeroID = FindNextCreature(id);

            if (nextHeroID > -1)
            {
                var nextHero = heroes.Find(nextHeroID);
                string nextUser = "Player " + nextHero.GetId();
                command = new EndTurnCommand(nextHero);
                await SendMessage(nextUser, "Your Turn!");
                controller.Run(command);
                await SendStateToSpecificClient(players.First(x => x.Value == nextHero.GetId()).Key);
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

            await GetPlayerCoordinates(id);
        }

        public async Task UndoPlayer(int id)
        {
            var hero = heroes.Find(id);
            string user = "Player " + hero.GetId();

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
            await GetPlayerCoordinates(id);
        }

        public async Task PlayerDeath(int id)
        {
            var hero = heroes.Find(id);
            string user = "Player " + hero.GetId();

            bool flag = hero.ReceiveDamage(999);

            if (!flag)
            {
                await SendMessage(user, "Player has died!");
                await SendStateToCaller();

                int nextID = FindNextCreature(id);
                switch (nextID)
                {
                    case -1:
                        await SendGlobalMessage("All players have died!");
                        break;
                    case -2:
                        break;
                    default:
                        var nextHero = heroes.Find(nextID);
                        string nextUser = "Player " + nextHero.GetId();
                        
                        var command = new EndTurnCommand(nextHero);
                        await SendMessage(nextUser, "Your Turn!");
                        controller.Run(command);
                        await SendStateToSpecificClient(players.First(x => x.Value == nextHero.GetId()).Key);
                        break;
                }
            }

        }


        public Task GetPlayerCoordinates(int id)
        {
            var hero = heroes.Find(id);

            return Clients.All.SendAsync("PlayerNewCoordinates", id, hero.GetPosX(), hero.GetPosY());
        }

        private static AbstractLogger GetChainOfLoggers()
        {
            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger debugLogger = new DebugLogger(AbstractLogger.DEBUG);
            AbstractLogger infoLogger = new InfoLogger(AbstractLogger.INFO);

            errorLogger.SetNextLogger(debugLogger);
            debugLogger.SetNextLogger(infoLogger);

            return errorLogger;
        }
        #endregion

        public int FindNextCreature(int id)
        {
            int result = -1;
            bool resultFlag = false;
            bool valueFlag = true;
            foreach(Creature creature in heroes)
            {
                string state = creature.GetState();
                int creatureID = creature.GetId();
                Console.WriteLine($"{creature.GetName()} {creatureID} - State - {state}");
                switch(state)
                {
                    case "ReadyState":
                        resultFlag = true;
                        break;
                    case "WaitingTurnState":
                        if (result < 0)
                        {
                            result = creatureID;
                        }
                        if (creatureID > id && valueFlag)
                        {
                            result = creatureID;
                            valueFlag = false;
                        }
                        break;
                }
            }

            if (resultFlag)
            {
                return -2;
            }
            else
            {
                return result;
            }
        }

    }
}
