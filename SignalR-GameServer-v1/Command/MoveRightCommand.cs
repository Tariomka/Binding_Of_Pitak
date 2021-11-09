using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Command
{
    public class MoveRightCommand : ICommand
    {
        public MoveRightCommand (Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.move("RIGHT");
        }

        public override void undo()
        {
            target.move("LEFT");
        }
    }
}
