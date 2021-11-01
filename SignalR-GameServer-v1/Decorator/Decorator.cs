using SignalR_GameServer_v1.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Decorator
{
    public abstract class Decorator : Creature
    {
        protected Creature wrapee;

        public Decorator ( Creature component)
        {
            wrapee = component;
        }

        public override int GetSpeed()
        {
            return wrapee.GetSpeed();
        }
    }
}
