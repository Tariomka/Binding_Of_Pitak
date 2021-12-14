using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Composite
{
    public class Division : GroupedCreature
    {
        private List<GroupedCreature> creatureList = new List<GroupedCreature>();
        public void Add(GroupedCreature creature)
        {
            creatureList.Add(creature);
        }
        public void Remove(GroupedCreature creature)
        {
            creatureList.RemoveAt(creatureList.IndexOf(creature));
        }
        
        public List<GroupedCreature> GetCreatures()
        {
            return creatureList;
        }

        public void Move(string direction, bool flag)
        {
            foreach (var creature in creatureList)
            {
                creature.Move(direction, flag);
            }
        }

        public bool isCreature()
        {
            return false;
        }
    }
}
