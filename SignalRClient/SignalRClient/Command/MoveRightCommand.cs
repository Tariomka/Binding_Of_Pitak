using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class MoveRightCommand : ICommand
    {
        public MoveRightCommand (Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.move("Right");
        }

        public override void undo()
        {
            target.move("Left");
        }
    }
}
