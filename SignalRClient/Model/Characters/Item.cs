using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Item
    {
        private int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string effect { get; set; }
        public int usage { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
    }
}
