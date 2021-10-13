using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Map
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
