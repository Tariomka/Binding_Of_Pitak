using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        public int mapHeight;
        public int mapWidth;
        private Guid uid = Guid.NewGuid();
        private Dictionary<int, PictureBox> players = new Dictionary<int, PictureBox>();
        private int playerid = 0;
        private string playerName => $"Player {playerid}";

        public Form1()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44332/GameHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Invoke((Action)(() =>
                {
                    var newMessage = $"{user}: {message}";
                    messagesList.Items.Add(newMessage);
                }));
            });

            connection.On<int, string>("ReceiveCoordinates", (pid, direction) =>
            {
                movePlayer(pid, direction);
            });

            connection.On<int, int, int>("PlayerNewCoordinates", (playerid, posx, posy) =>
            {
                PaintNewPlayerPosition(playerid, posx, posy);
            });

            connection.On("SwitchState", () =>
            {
                SwitchButtonsState();
            });

            //connection.On<int, int>("ReceiveMapCoordinates", (x, y) =>
            //{
            //    mapWidth = x;
            //    mapHeight = y;
            //});

            connection.On<int, Dictionary<string, int>, List<KeyValuePair<Point, string>>, List<KeyValuePair<Point, string>>>("GameJoined", (id, playersInGame, tiles, items) =>
            {
                this.OnGameJoined(id, playersInGame, tiles, items);
            });

            
            connection.On<int>("PlayerJoined", (id) =>
            {
                this.OnNewPlayerJoined(id);
            });

            try
            {
                messagesList.Items.Add("Connecting to game server...");
                await connection.StartAsync();
                messagesList.Items.Add("Done");

                messagesList.Items.Add("Joining the game...");
                await connection.InvokeAsync("JoinGame", this.uid);

                //await connection.InvokeAsync("GetMapSize");
                //messagesList.Items.Add("Map size:" + mapWidth + " " + mapHeight);


                //connectButton.IsEnabled = false;
                //sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        #region Map and Tiles Logic

        private void GenerateMap(List<KeyValuePair<Point, string>> tiles, List<KeyValuePair<Point, string>> items)
        {
            AddMessage("Generating map...");

            foreach (var item in items)
            {
                AddItem(point: item.Key, itemType: item.Value);
            }
            foreach (var tile in tiles)
            {
                AddTile(point: tile.Key, tileType: tile.Value);
            }
            AddMessage("Done.");
        }

        private void AddTile(Point point, string tileType)
        {
            var picture = new PictureBox
            {
                Name = $"tile_{point.X}_{point.Y}_tileType",
                Size = new Size(40, 40),
                Location = new Point(point.X * 40, point.Y * 40),
                Image = GetTileImage(tileType)
            };
            this.Controls.Add(picture);
            this.picCanvas.SendToBack();
        }

        private Bitmap GetTileImage(string tyleType)
        {
            switch (tyleType)
            {
                case "Grass":
                    return Properties.Resources.grass;
                case "Lava":
                    return Properties.Resources.lava;
                case "Dirt":
                    return Properties.Resources.dirt;
                default:
                    return Properties.Resources.grass;
            }
        }

        private void AddItem(Point point, string itemType)
        {
            var picture = new PictureBox
            {
                Name = $"item_{point.X}_{point.Y}_itemType",
                Size = new Size(40, 40),
                Location = new Point(point.X * 40, point.Y * 40),
                Image = GetItemImage(itemType)
            };
            this.Controls.Add(picture);
            this.picCanvas.SendToBack();
        }

        private Bitmap GetItemImage(string itemType)
        {
            switch (itemType)
            {
                case "minorheal":
                    return Properties.Resources.minorheal;
                case "majorheal":
                    return Properties.Resources.majorheal;
                case "bluegun":
                    return Properties.Resources.bluegun;
                case "greengun":
                    return Properties.Resources.greengun;
                case "blueenergy":
                    return Properties.Resources.blueenergy;
                case "greenenergy":
                    return Properties.Resources.greenenergy;
                default:
                    return Properties.Resources.minorheal;
            }
        }

        #endregion


        private void OnGameJoined(int id, Dictionary<string, int> playersInGame, List<KeyValuePair<Point, string>> tiles, List<KeyValuePair<Point, string>> items)
        {
            this.playerid = id;
            AddMessage($"My Player ID is: {this.playerid}");
            AddMessage($"Players in game: {string.Join(",", playersInGame.Values.ToArray())}");

            try
            {
                this.GenerateMap(tiles, items);
                this.GeneratePlayers(playersInGame);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }

        private void GeneratePlayers(Dictionary<string, int> playersInGame)
        {
            AddMessage("Generating players...");
            foreach(var id in playersInGame.Values)
            {
                this.AddPlayer(id);
            }
            AddMessage("Done");
        }

        private void OnNewPlayerJoined(int id)
        {
            this.AddPlayer(id);
        }


        private void AddPlayer(int id)
        {
            if (!players.ContainsKey(id))
                this.players.Add(id, GetNewPlayer(id));

            messagesList.Items.Add($"!! Player ID {this.playerid} has joined the game");
        }

        private void AddMessage(string message)
        {
            messagesList.Items.Add(message);
        }

        private PictureBox GetNewPlayer(int id)
        {
            var pb = new PictureBox();
            //((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
            // 
            pb.BackColor = Color.Transparent;
            pb.Image = this.playerid == id ? Properties.Resources.player : Properties.Resources.enemy;
            pb.Location = new Point(480, 320);
            pb.Name = $"Player{id}";
            pb.Size = new Size(40, 40);
            pb.TabIndex = 20 + id;
            pb.TabStop = false;
            pb.Visible = true;

            this.Controls.Add(pb);
            pb.BringToFront();
            //((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
            AddMessage($"Player {id} has been added to the map.");
            return pb;
        }

        private void UP_Click(object sender, EventArgs e)
        {
            try
            {
                movePlayer(this.playerid, "UP");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                movePlayer(this.playerid, "DOWN");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void RIGHT_Click(object sender, EventArgs e)
        {
            try
            {
                movePlayer(this.playerid, "RIGHT");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void LEFT_Click(object sender, EventArgs e)
        {
            try
            {
                movePlayer(this.playerid, "LEFT");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void UNDO_Click(object sender, EventArgs e)
        {
            try
            {
                _ = SendUndoPlayer(this.playerid);
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void ENDTURN_Click(object sender, EventArgs e)
        {
            try
            {
                _ = SendEndPlayerTurn(this.playerid);
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void SwitchButtonsState()
        {
            UP.Enabled = !UP.Enabled;
            DOWN.Enabled = !DOWN.Enabled;
            LEFT.Enabled = !LEFT.Enabled;
            RIGHT.Enabled = !RIGHT.Enabled;
            UNDO.Enabled = !UNDO.Enabled;
            ENDTURN.Enabled = !ENDTURN.Enabled;
        }

        private void movePlayer(int pid, string direction)
        {
            var player = players[pid];
            player.BringToFront();

            int x = player.Location.X;
            int y = player.Location.Y;

            _ = SendMovePlayer(this.playerid, direction);

            /*if (direction == "RIGHT") x += 40;
            else if (direction == "LEFT") x -= 40;
            else if (direction == "UP") y -= 40;
            else if (direction == "DOWN") y += 40;
            player.Location = new Point(x, y);

            // if this is me, let other know that i moved
            // otherwise just move the piece and don't send message
            if (pid == this.playerid)
            {
                _ = SendGetCoordinatesAsync(this.playerid, direction);
            }*/
        }

        private async Task SendGetCoordinatesAsync(int pid, string direction)
        {
            await connection.InvokeAsync("SendCoordinates",
                    pid, direction);
        }

        private async Task SendMovePlayer(int pid, string direction)
        {
            await connection.InvokeAsync("MovePlayer",
                    pid, direction);
        }

        private async Task SendEndPlayerTurn(int pid)
        {
            await connection.InvokeAsync("EndPlayerTurn", pid);
        }

        private async Task SendUndoPlayer(int pid)
        {
            await connection.InvokeAsync("UndoPlayer", pid);
        }

        private void PaintNewPlayerPosition(int playerid, int posx, int posy)
        {
            var player = players[playerid];
            player.BringToFront();

            player.Location = new Point(posx, posy);
        }
    }
}
