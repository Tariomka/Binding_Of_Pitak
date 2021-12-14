using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary.Template
{
    abstract class MapTemplate
    {
        public Map GetMapTemplate(Map map, List<KeyValuePair<string, double>> tileTypes, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    AddTile(map, tileTypes, x, y);
                    if (withItems())
                    {
                        if (random.Next(1, width + height) < 3)
                        {
                            AddItem(map, tileTypes, x, y);
                        }
                    }
                }
            }
            LogMapTemplate(withItems());
            return map;
        }

        protected abstract void AddTile(Map map, List<KeyValuePair<string, double>> tileTypes, int x, int y);

        protected abstract void AddItem(Map map, List<KeyValuePair<string, double>> tileTypes, int x, int y);

        public abstract bool withItems();

        protected Random random = new Random();

        protected void LogMapTemplate(bool items)
        {
            if(items)
                Console.WriteLine(String.Format("Map template is with items."));
            else
                Console.WriteLine(String.Format("Map template is without items."));
            return;
        }
    }
}
