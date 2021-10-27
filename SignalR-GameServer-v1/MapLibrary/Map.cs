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
        private int sizeX { get; set; }
        private int sizeY { get; set; }

        List<Tile> _tile;
        TileFactory _grass = new GrassFactory(1);
        TileFactory _lava = new LavaFactory(1);
        public MapSettings Settings;

        
        public Map(int id)
        {
            Settings = MapSettings.GetInstance();
            this.id = id;
            sizeX = Settings.MapWidth;
            sizeY = Settings.MapHeight;
            _tile = new List<Tile>();
            GenerateMap();
        }

        private void GenerateMap()
        {
            
            for (int i = 0; i < Settings.MapHeight; i+=40)
            {
                for (int j = 0; j < Settings.MapWidth; j+=40)
                {
                    _tile.Add(GetTile());
                }
            }
        }
        public string[,] GetLayout()
        {
            int h = Settings.MapHeight / 40;
            int w = Settings.MapWidth / 40;
            string[,] retArray = new string[h,w];
            for (int i = 0; i < h; i ++)
            {
                for (int j = 0; j < w; j ++)
                {                    
                    retArray[i, j] = _tile[i * 4 + j].image;
                }
            }
            return retArray;
        }

        private Tile GetTile()
        {
            Random rnd = new Random();
            int k = rnd.Next(5);
            if (k < 4)
                return _grass.GetTile();
            else
                return _lava.GetTile();
        }
    }
}
