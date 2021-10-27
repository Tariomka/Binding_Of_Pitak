using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.MapLibrary
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
