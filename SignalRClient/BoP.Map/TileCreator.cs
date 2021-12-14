using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    public class TileCreator : Creator
    {
        public override Tile factoryMethod(string tileType)
        {
            if(tileType == "Grass")
            {
                return new GrassTile(1);
            }
            if(tileType == "Lava")
            {
                return new LavaTile(1);
            }
            if (tileType == "Dirt")
            {
                return new DirtTile(1);
            }
            return null;
        }
    }
}
