using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Hero : Creature, ICloneable
    {
        private List<Item> itemList;
        public Hero() : base()
        {
            itemList = new List<Item>();
            this.SetName("");
        }

        public Hero(int id, string name, int health, int speed, int actionCount, int posx, int posy) : base(id, name, health, speed, actionCount, posx, posy)
        {
            itemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public void LoseItem() { itemList.RemoveAt(0); }

        //shallowcopy
        public new Hero ShallowCopy()
        {
            return (Hero)this.MemberwiseClone();
        }
        //deepcopy
        public new Hero Clone()
        {
            Hero copy = (Hero)this.MemberwiseClone();
            copy.setServer(this.GetServer());
            List<Item> newList = new List<Item>(this.itemList.Count);
            itemList.ForEach((item) =>
            {
                newList.Add(new Item(item));
            });
            copy.itemList = newList;
            return copy;
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
