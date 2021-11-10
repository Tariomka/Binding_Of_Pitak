using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    public abstract class Creator
    {
        public abstract Tile factoryMethod(String tileType);
    }
}
