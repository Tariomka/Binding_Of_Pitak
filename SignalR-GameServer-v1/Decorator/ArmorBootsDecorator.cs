using SignalR_GameServer_v1.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Decorator
{
    public class ArmorBootsDecorator : Decorator
    {
        public ArmorBootsDecorator(Hero component) : base(component)
        {
           
        }

        public override int GetSpeed()
        {
            return base.GetSpeed() + 1;
        }
    }
}
