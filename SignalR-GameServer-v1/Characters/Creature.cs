using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Creature
    {
        private int id { get; set; }
        public int health { get; set; }
        public int speed { get; set; }
        public int actionCount { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
    }
}
