using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRClient.ConnectionProxy
{
    public class HubConnectionProxy : ConnectionInterface
    {
        public ConnectionInterface hubConnectionAdapter { get; private set; }
        private string path = "./ProxyLogs.txt";
        public HubConnectionProxy()
        {
            this.hubConnectionAdapter = new HubConnectionAdapter();
        }

        public Task InvokeAsync(string ip, string methodName, object obj1)
        {
            WriteToFile(methodName + " " + ip);
            return hubConnectionAdapter.InvokeAsync("", methodName, obj1);
        }

        private void WriteToFile(string info)
        {
            using (StreamWriter fs = File.AppendText(this.path))
            {
                fs.WriteLine(info + DateTime.Now.ToString());
            }
        }

        public IDisposable On(string methodName, Action<string, string> handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int, string> handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int, int, int > handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int, Dictionary<string, int>, List<KeyValuePair<Point, string>>, List<KeyValuePair<Point, string>>> handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<int> handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }
        public Task StartAsync()
        {
            return hubConnectionAdapter.StartAsync();
        }

        public Task InvokeAsync(string ip, string methodName, object obj1, object obj2)
        {
            WriteToFile(methodName +" " + ip);
            return hubConnectionAdapter.InvokeAsync("", methodName, obj1, obj2);
        }

        public IDisposable On(string methodName, Action handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }

        public IDisposable On(string methodName, Action<string> handler)
        {
            return hubConnectionAdapter.On(methodName, handler);
        }

    }
}
