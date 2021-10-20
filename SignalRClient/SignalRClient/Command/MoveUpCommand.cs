using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class MoveUpCommand : ICommand
    {
        public MoveUpCommand (Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.move("Up");
        }

        public override void undo()
        {
            target.move("Down");
        }
    }
}
