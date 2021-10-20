using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class MoveDownCommand : ICommand
    {
        public MoveDownCommand (Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.move("Down");
        }

        public override void undo()
        {
            target.move("Up");
        }
    }
}
