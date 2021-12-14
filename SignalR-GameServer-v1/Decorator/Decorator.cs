using SignalR_GameServer_v1.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Decorator
{
    public abstract class Decorator : Hero
    {
        public Decorator(Hero component) : base (component.GetId(), component.GetName(),component.GetHealth(), component.GetSpeed(),component.GetActionCount(), component.GetPosX(),component.GetPosY())
        {
        }

        public override int GetSpeed()
        {
            return base.GetSpeed();
        }

    }
}
