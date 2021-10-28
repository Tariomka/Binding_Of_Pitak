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

        List<Tile> tiles;
        TileFactory grass = new GrassFactory(1);
        TileFactory lava = new LavaFactory(1);
        public MapSettings settings;
        private string[,] layout;

        
        public Map()
        {
            settings = MapSettings.getInstance();
            sizeX = settings.mapWidth/40;
            sizeY = settings.mapHeight/40;
            layout = new string[sizeX, sizeY];
            tiles = new List<Tile>();
            GenerateMap();
        }

        public void AddTile(Tile tile)
        {
            tiles.Add(tile);
        }

        private void GenerateMap()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    tiles.Add(GetGrassTile());
                    layout[i, j] = tiles.Last().type;
                }
            }
            //for (int i = 0; i < settings.mapHeight; i+=40)
            //{
            //    for (int j = 0; j < settings.mapWidth; j+=40)
            //    {
            //        tile.Add(GetTile());
            //    }
            //}
        }


        public void Construct(IBuilder builder)
        {
            //builder.addTiles();
            //builder.assembleLayout();
        }


        public string[,] GetLayout()
        {
            int h = settings.mapHeight / 40;
            int w = settings.mapWidth / 40;
            string[,] retArray = new string[h,w];
            for (int i = 0; i < h; i ++)
            {
                for (int j = 0; j < w; j ++)
                {                    
                    retArray[i, j] = tiles[i * 4 + j].image;
                }
            }
            return retArray;
        }

        private Tile GetGrassTile()
        {
            return grass.GetTile();
        }

        private Tile GetLavaTile()
        {
            return lava.GetTile();
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
