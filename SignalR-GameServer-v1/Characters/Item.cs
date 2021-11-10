using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Item
    {
        private int id;
        private string name;
        private string type;
        private string effect;
        private int usage;
        private int posX;
        private int posY;

        public Item()
        {
            this.id = 0;
            this.name = "";
            this.type = "";
            this.effect = "";
            this.usage = 0;
            this.posX = 0;
            this.posY = 0;
        }

        public Item(Item old) 
        {
            id = old.id;
            name = old.name;
            type = old.type;
            effect = old.type;
            usage = old.usage;
            posX = old.posX;
            posY = old.posY;
        }

        public Item(int id, string name, string type, string effect, int usage, int posX, int posY)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.effect = effect;
            this.usage = usage;
            this.posX = posX;
            this.posY = posY;
        }
    }
}
