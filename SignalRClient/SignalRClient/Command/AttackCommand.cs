using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class AttackCommand : ICommand
    {
        public AttackCommand(Creature target) : base(target)
        {

        }
        public override void execute()
        {
            target.attack();
        }

        public override void undo()
        {
            // Restore the attack with a prototype deep copy?
        }
    }
}
