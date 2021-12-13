using SignalR_GameServer_v1.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.States
{
    public abstract class State
    {
        protected Creature _creature;

        public void SetContext(Creature creature)
        {
            this._creature = creature;
        }

        public abstract void Move(string direction, bool flag);
        public abstract void Attack();
        public abstract void EndTurn();
        public abstract void UseItem();
    }
}
