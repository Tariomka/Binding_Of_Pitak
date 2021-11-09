using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    class GrassFactory : TileFactory
    {
        private int _cost;

        public GrassFactory(int cost)
        {
            _cost = cost;
        }

        public override Tile GetTile()
        {
            return new GrassTile(_cost);
        }
    }
}
