using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace SignalRClient.ConnectionProxy
{
    class HubConnectionAdapter : ConnectionInterface
    {
        public HubConnection connection { get; private set; }

        public HubConnectionAdapter()
        {
            this.connection = new HubConnectionBuilder().WithUrl("https://localhost:44332/GameHub").Build();
        }

        public Task InvokeAsync(string ip, string methodName, object obj1)
        {
            return connection.InvokeAsync(methodName, obj1);
        }

        public IDisposable On(string methodName, Action<string, string> handler)
        {
            return connection.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int, string> handler)
        {
            return connection.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int, int, int> handler)
        {
            return connection.On(methodName, handler);
        }
        public IDisposable On(string methodName, Action<int, Dictionary<string, int>, List<KeyValuePair<Point, string>>> handler)
        {
            return connection.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int> handler)
        {
            return connection.On(methodName, handler);
        }

        public Task StartAsync()
        {
            return connection.StartAsync();
        }

        public Task InvokeAsync(string ip, string methodName, object obj1, object obj2)
        {
            return connection.InvokeAsync(methodName, obj1, obj2);
        }
    }
}

