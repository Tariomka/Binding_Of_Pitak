using System;
using System.Collections.Generic;

namespace BoP.MapLibrary
{
    public class MapBuilder : IMapBuilder
    {
        private List<KeyValuePair<string, double>> tileTypes = new List<KeyValuePair<string, double>>();
        private Random random = new Random();
        Item item;

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
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map.AddTile(x, y, GetNextTile());
                    if(random.Next(1, width + height) < 3)
                    {
                        item = GetNextItem(x, y);
                        map.AddItem(x, y, item);
                    }
                }
            }
            return map;
        }

        private string GetNextTile()
        {
            switch (tileTypes.Count)
            {
                case 0:
                    return TileTypes.Tiles[0];
                case 1:
                    return tileTypes[0].Key;
                default:
                    var next = this.random.Next(1, tileTypes.Count + 1);
                    return tileTypes[next - 1].Key;
            }
        }

        private Item GetNextItem(int x, int y)
        {
            AbstractFactory itemFactory;
            //nustatoma ar retas itemas, ar paprastas
            var next = this.random.Next(1, 15);
            if (next == 2)
            {
                itemFactory = new RareItemsFactory();
            }
            else
            {
                itemFactory = new CommonItemsFactory();
            }
            var next2 = this.random.Next(1, 6);
            if (next2 < 2)
            {
                return itemFactory.createHeal(this.random.Next(), x, y);
            }
            if (next2 < 4)
            {
                return itemFactory.createGun(this.random.Next(), x, y);
            }
            else
            {
                return itemFactory.createEnergy(this.random.Next(), x, y);
            }
        }

    }
}
