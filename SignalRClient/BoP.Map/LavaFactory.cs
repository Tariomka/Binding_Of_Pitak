using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    class LavaFactory : TileFactory
    {
        private int _cost;

        public LavaFactory(int cost)
        {
            _cost = cost;
        }

        public override Tile GetTile()
        {
            return new LavaTile(_cost);
        }
    }
}
