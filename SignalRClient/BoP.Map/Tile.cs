using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    public abstract class Tile
    {
        public abstract string type { get; }
        public abstract string image { get; }
        public abstract int cost { get; set; }

        public abstract int posX { get; }
        public abstract int posY { get; }

        public abstract void SetPosition(int x, int y);
    }
    
}
