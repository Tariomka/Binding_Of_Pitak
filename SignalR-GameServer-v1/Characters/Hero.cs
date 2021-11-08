using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Hero : Creature
    {
        public List<Item> itemList;
        public string name { get; set; }

        

        public void Move (string direction)
        {
            
        }
    }
}
