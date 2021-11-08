using SignalR_GameServer_v1.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Decorator
{
    public class ArmorBootsDecorator : Decorator
    {
        public ArmorBootsDecorator(Creature component) : base(component)
        {
           
        }

        public void IncreaseSpeed()
        {
            wrapee.SetSpeed(wrapee.GetSpeed()+1);
        }

        public override int GetSpeed()
        {
            IncreaseSpeed();
            return base.GetSpeed();
        }
    }
}
