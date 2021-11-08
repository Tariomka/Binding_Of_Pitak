using System.Collections.Generic;
using System.Drawing;

namespace BoP.MapLibrary
{
    public class Map
    {
        public List<KeyValuePair<Point, string>> Tiles = new List<KeyValuePair<Point, string>>();

        public void AddTile(int x, int y, string tyleType)
        {
            this.Tiles.Add(
                new KeyValuePair<Point, string>(
                    new Point(x, y), tyleType));
        }
    }


}