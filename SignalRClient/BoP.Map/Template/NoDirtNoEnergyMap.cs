using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary.Template
{
    class NoDirtNoEnergyMap : MapTemplate
    {        

        protected override void AddTile(Map map, List<KeyValuePair<string, double>> tileTypes, int x, int y)
        {
            string newTile;            
            switch (tileTypes.Count)
            {
                case 0:
                    newTile = TileTypes.Tiles[0];
                    break;
                case 1:
                    newTile = tileTypes[0].Key;
                    break;
                default:
                    var next = this.random.Next(1, tileTypes.Count + 1);
                    if(tileTypes[next - 1].Key == "Dirt")
                    {
                        if(this.random.Next(0, 2) < 1)
                            newTile = tileTypes[next - 2].Key;
                        else
                            newTile = tileTypes[next - 3].Key;
                    }
                    else 
                    {
                        newTile = tileTypes[next - 1].Key;
                    }
                    break;
            }
            map.AddTile(x, y, newTile);
        }

        protected override void AddItem(Map map, List<KeyValuePair<string, double>> tileTypes, int x, int y)
        {
            Item item;
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
            if (next2 < 3)
            {
                item = itemFactory.createHeal(this.random.Next(), x, y);
            }
            else
            {
                item = itemFactory.createGun(this.random.Next(), x, y);
            }
            map.AddItem(x, y, item);
        }

        public override bool withItems()
        {
            return true;
        }
    }
}
