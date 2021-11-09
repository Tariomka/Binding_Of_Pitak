using System.Collections.Generic;
using System.Drawing;

namespace BoP.MapLibrary
{
    public class Map
    {
        public List<KeyValuePair<Point, string>> frameTiles = new List<KeyValuePair<Point, string>>();
        GrassFactory grassFactory = new GrassFactory(1);
        LavaFactory lavaFactory = new LavaFactory(1);
        public List<Tile> tiles = new List<Tile>();
        Tile tile;

        public void AddTile(int x, int y, string tileType)
        {
            //old
            //this.Tiles.Add(
            //    new KeyValuePair<Point, string>(
            //        new Point(x, y), tileType));
            //new
            switch (tileType)
            {
                case "Lava":
                    tile = lavaFactory.GetTile();
                    tile.SetPosition(x, y);
                    tiles.Add(tile);
                    this.frameTiles.Add(
                        new KeyValuePair<Point, string>(
                            new Point(x, y), tileType));                    
                    break;
                case "Grass":
                    tile = grassFactory.GetTile();
                    tile.SetPosition(x, y);
                    tiles.Add(tile);
                    this.frameTiles.Add(
                        new KeyValuePair<Point, string>(
                            new Point(x, y), tileType));
                    break;
                default:
                    break;
            }
        }
        public List<KeyValuePair<Point, string>> GetLayout()
        {
            List<KeyValuePair<Point, string>> layout = new List<KeyValuePair<Point, string>>();
            foreach (var t in tiles)
            {
                layout.Add(new KeyValuePair<Point, string>(
                    new Point(t.posX, t.posY), t.type));
            }
            return layout;
        }


    }
}