using System;
using System.Collections.Generic;

namespace BoP.MapLibrary
{
    public class MapBuilder : IMapBuilder
    {
        private List<KeyValuePair<string, double>> tyleTypes = new List<KeyValuePair<string, double>>();
        private Random random = new Random();

        public MapBuilder AddTile(string TileType)
        {
            this.tyleTypes.Add(new KeyValuePair<string, double>(TileType, 0));
            return this;
        }

        public Map Build(int width, int height)
        {
            var map = new Map();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map.AddTile(x, y, GetNextTile());
                }
            }
            return map;
        }

        private string GetNextTile()
        {
            switch (tyleTypes.Count)
            {
                case 0:
                    return TileTypes.Tiles[0];
                case 1:
                    return tyleTypes[0].Key;
                default:
                    var next = this.random.Next(1, tyleTypes.Count + 1);
                    return tyleTypes[next - 1].Key;
            }
        }
    }
}
