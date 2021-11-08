using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using BoP.MapLibrary;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public static MapSettings Settings = MapSettings.getInstance();

        public int mapWidth = settings.mapWidth;
        public int mapHeight = settings.mapHeight;
        public static int playerIndex = 0;
        public static Dictionary<string, int> players = new Dictionary<string, int>();
        public static Map gameMap = null;


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

            if (!Players.ContainsKey(playerid))
            {
                PlayerIndex++;
                Players.Add(playerid, PlayerIndex);
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

        #endregion

    }
}
