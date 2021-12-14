using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Map
{
    class Map
    {
        Tile tile;
        TileFactory grass = new GrassFactory(1);
        TileFactory lava = new LavaFactory(1);


        public Tile GetTile()
        {
            Random rnd = new Random();
            int k = rnd.Next(5);
            if (k == 1)
                return grass.GetTile();
            if (k == 2)
                return lava.GetTile();
            return null;
        }
    }
}
