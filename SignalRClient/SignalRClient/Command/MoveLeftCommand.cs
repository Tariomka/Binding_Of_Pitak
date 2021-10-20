using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class MoveLeftCommand : ICommand
    {
        public MoveLeftCommand (Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.move("Left");
        }

        public override void undo()
        {
            target.move("Right");
        }
    }
}
