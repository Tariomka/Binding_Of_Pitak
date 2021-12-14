using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.States;

namespace SignalR_GameServer_v1.Composite
{
    public interface GroupedCreature
    {
        public bool isCreature();
        public void Move(string direction, bool flag);
        public void TransitionTo(State state);
        public List<GroupedCreature> GetCreatures();
        public int GetPosX();
        public int GetPosY();
    }
}
