using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Map
{
    abstract class TileFactory
    {
        public abstract Tile GetTile();
    }
}
