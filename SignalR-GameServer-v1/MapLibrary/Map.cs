using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.MapLibrary
{
    public class Map
    {
        private int id { get; set; }
        private int lavelNum { get; set; }
        private int sizeX { get; set; }
        private int sizeY { get; set; }

        List<Tile> tile;
        TileFactory grass = new GrassFactory(1);
        TileFactory lava = new LavaFactory(1);
        public MapSettings Settings;

        
        public Map(int id)
        {
            Settings = MapSettings.getInstance();
            this.id = id;
            sizeX = Settings.mapWidth;
            sizeY = Settings.mapHeight;
            tile = new List<Tile>();
            GenerateMap();
        }

        private void GenerateMap()
        {
            
            for (int i = 0; i < Settings.mapHeight; i+=40)
            {
                for (int j = 0; j < Settings.mapWidth; j+=40)
                {
                    tile.Add(GetTile());
                }
            }
        }
        public string[,] GetLayout()
        {
            int h = Settings.mapHeight / 40;
            int w = Settings.mapWidth / 40;
            string[,] retArray = new string[h,w];
            for (int i = 0; i < h; i ++)
            {
                for (int j = 0; j < w; j ++)
                {                    
                    retArray[i, j] = tile[i * 4 + j].image;
                }
            }
            return retArray;
        }

        private Tile GetTile()
        {
            Random rnd = new Random();
            int k = rnd.Next(5);
            if (k < 4)
                return grass.GetTile();
            else
                return lava.GetTile();
        }
    }
}
