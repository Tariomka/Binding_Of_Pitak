using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Composite
{
    public interface GroupedCreature
    {
        public bool isCreature();
        public void Move(string direction, bool flag);
        public List<GroupedCreature> GetCreatures();
    }
}
