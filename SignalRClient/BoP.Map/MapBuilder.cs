using System;
using System.Collections.Generic;
using BoP.MapLibrary.Template;

namespace BoP.MapLibrary
{
    public class MapBuilder : IMapBuilder
    {
        private List<KeyValuePair<string, double>> tileTypes = new List<KeyValuePair<string, double>>();
        private Random random = new Random();

        public MapBuilder AddTile(string TileType)
        {
            this.tileTypes.Add(new KeyValuePair<string, double>(TileType, 0));
            return this;
        }

        public void BuildGrassTile()
        {
            this.tileTypes.Add(new KeyValuePair<string, double>("Grass", 0));
        }
        public void BuildLavaTile()
        {
            this.tileTypes.Add(new KeyValuePair<string, double>("Lava", 0));
        }
        public void BuildDirtTile()
        {
            this.tileTypes.Add(new KeyValuePair<string, double>("Dirt", 0));
        }
        public void AddItem()
        {

        }

        public Map Build(int width, int height)
        {
            var map = new Map();

            //MapTemplate template = new NoDirtNoEnergyTemplate();
            MapTemplate template = new NoLavaCommonItemsMap();
            map = template.GetMapTemplate(map, tileTypes, width, height);
            
            return map;
        }
    }
}
