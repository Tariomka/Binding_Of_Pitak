using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Command
{
    public class MoveLeftCommand : ICommand
    {
        public MoveLeftCommand (Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.SetPosX(target.getPosX() -40 );
            target.move("Left");
        }

        public override void undo()
        {
            target.move("Right");
        }
    }
}
