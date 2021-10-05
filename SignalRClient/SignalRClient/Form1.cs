﻿using System;
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

            if (direction == "RIGHT") x += 10;
            else if (direction == "LEFT") x -= 10;
            else if (direction == "UP") y -= 10;
            else if (direction == "DOWN") y += 10;
            pictureBox1.Location = new Point(x, y);
            _ = SendGetCoordinatesAsync(x, y);
        }

        private async Task SendGetCoordinatesAsync(int x, int y)
        {
            await connection.InvokeAsync("SendCoordinates",
                    x.ToString(), y.ToString());
        }

    }
}