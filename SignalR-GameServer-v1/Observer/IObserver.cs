using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Observer
{
    public interface IObserver
    {
        void update(string msg);

        void notifyServer(string result);

        void setServer(Subject server);
    }
}
