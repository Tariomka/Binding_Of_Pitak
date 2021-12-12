using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Drawing;

namespace SignalRClient.ConnectionProxy
{
    public interface ConnectionInterface
    {
        Task InvokeAsync(string ip, string methodName, object obj1);
        IDisposable On(string methodName, Action<string, string> handler);
        IDisposable On(string methodName, Action<int, string> handler);

        IDisposable On(string methodName, Action<int, int, int> handler);

        IDisposable On(string methodName, Action<int, Dictionary<string, int>, List<KeyValuePair<Point, string>>> handler);
        IDisposable On(string methodName, Action<int> handler);

        Task StartAsync();

        Task InvokeAsync(string ip, string methodName, object obj1, object obj2);

    }
}
