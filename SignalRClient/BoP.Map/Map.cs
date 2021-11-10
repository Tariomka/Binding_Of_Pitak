using System.Collections.Generic;
using System.Drawing;

namespace BoP.MapLibrary
{
    public class Map
    {
        public List<KeyValuePair<Point, string>> frameTiles = new List<KeyValuePair<Point, string>>();        
        public List<Tile> tiles = new List<Tile>();
        public List<KeyValuePair<Point, string>> frameItems = new List<KeyValuePair<Point, string>>();
        public List<Item> items = new List<Item>();
        Creator tileCreator = new TileCreator();
        Tile tile;

        public void AddTile(int x, int y, string tileType)
        {
            //old
            //this.Tiles.Add(
            //    new KeyValuePair<Point, string>(
            //        new Point(x, y), tileType));
            //new
            //switch (tileType)
            //{
            //    case "Lava":
            //        tile = ctr.factoryMethod(tileType);
            //        tile.SetPosition(x, y);
            //        tiles.Add(tile);
            //        this.frameTiles.Add(
            //            new KeyValuePair<Point, string>(
            //                new Point(x, y), tileType));                    
            //        break;
            //    case "Grass":
            //        tile = ctr.factoryMethod(tileType);
            //        tile.SetPosition(x, y);
            //        tiles.Add(tile);
            //        this.frameTiles.Add(
            //            new KeyValuePair<Point, string>(
            //                new Point(x, y), tileType));
            //        break;
            //    default:
            //        break;
            //}
            tile = tileCreator.factoryMethod(tileType);
            tile.SetPosition(x, y);
            tiles.Add(tile);
            this.frameTiles.Add(
                new KeyValuePair<Point, string>(
                    new Point(x, y), tileType));
        }

        public void AddItem(int x, int y, Item item)
        {
            items.Add(item);
            this.frameItems.Add(
                new KeyValuePair<Point, string>(
                    new Point(x, y), item.name));
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