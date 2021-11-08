using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.MapLibrary
{
    public abstract class Tile
    {
        public abstract string type { get; }
        public abstract string image { get; } 
        public abstract int cost { get; set; }

    }
}
