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
using SignalRClient.Map;

namespace SignalRClient
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        TileFactory grass = new GrassFactory(1);
        TileFactory lava = new LavaFactory(1);

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

            connection.On<string, string>("ReceiveCoordinates", (x, y) =>
            {
                pictureBox2.Location = new Point(int.Parse(x), int.Parse(y));
            });

            try
            {
                await connection.StartAsync();
                messagesList.Items.Add("Connection started");
                createMap();

                //connectButton.IsEnabled = false;
                //sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void UP_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    "Player sends message: ", "move up!");
                messagesList.Items.Add("Player sends message: move up!");
                sendBoxCoordinates("UP");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    "Player sends message: ", "move down!");
                messagesList.Items.Add("Player sends message: move down!");
                sendBoxCoordinates("DOWN");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void RIGHT_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    "Player sends message: ", "move right!");
                messagesList.Items.Add("Player sends message: move right!");
                sendBoxCoordinates("RIGHT");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void LEFT_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    "Player sends message: ", "move left!");
                messagesList.Items.Add("Player sends message: move left!");
                sendBoxCoordinates("LEFT");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void sendBoxCoordinates(string direction)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if (direction == "RIGHT") x += 40;
            else if (direction == "LEFT") x -= 40;
            else if (direction == "UP") y -= 40;
            else if (direction == "DOWN") y += 40;
            pictureBox1.Location = new Point(x, y);
            _ = SendGetCoordinatesAsync(x, y);
        }

        private async Task SendGetCoordinatesAsync(int x, int y)
        {
            await connection.InvokeAsync("SendCoordinates",
                    x.ToString(), y.ToString());
        }

        private void createMap()
        {
            int width = picCanvas.Size.Width;
            int height = picCanvas.Size.Height;
            int a = 5;
            Random rnd = new Random();
            for (int i = 0; i < width; i += 40)
            {
                for (int j = 0; j < height; j += 40)
                {
                    a++;
                    Tile til = GetTile(rnd.Next(30));
                    string pictureName = String.Concat("pictureBox", a);
                    var picture = new PictureBox
                    {
                        Name = pictureName,
                        Size = new Size(40, 40),
                        Location = new Point(i, j),
                        Image = Image.FromFile(til.image),

                    };
                    this.Controls.Add(picture);
                }
            }
            this.picCanvas.SendToBack();
        }

        private Tile GetTile(int rnd)
        {
            if (rnd < 26)
                return grass.GetTile();
            else
                return lava.GetTile();
        }

    }
}
