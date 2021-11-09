using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Hero : Creature
    {
        private List<Item> itemList;
        public Hero() : base()
        {
            itemList = new List<Item>();
            this.SetName(0);
        }

        public Hero(string id, int name, int health, int speed, int actionCount, int posx, int posy) : base(id, name, health, speed, actionCount, posx, posy)
        {
            itemList = new List<Item>();
        }

        public void equipItem(Item item)
        {
            this.itemList.Add(item);
        }

        public int getItemCount()
        {
            return itemList.Count;
        }

        //TODO
        //public override void move(string direction)
        //{

        //}
    }
}
