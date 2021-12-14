using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Command
{
    public abstract class ICommand
    {
        protected Creature target;

        public ICommand(Creature target)
        {
            this.target = target;
        }

        public abstract void execute();

        public abstract void undo();
    }
}
