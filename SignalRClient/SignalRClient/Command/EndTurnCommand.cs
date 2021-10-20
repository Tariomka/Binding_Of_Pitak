using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class EndTurnCommand : ICommand
    {
        public EndTurnCommand(Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.endTurn();
        }

        public override void undo()
        {
            // Restore the turn with a prototype deep copy?
        }
    }
}
