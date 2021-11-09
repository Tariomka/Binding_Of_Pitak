using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Command
{
    public class AttackCommand : ICommand
    {
        public AttackCommand(Creature target) : base(target)
        {

        }
        public override void execute()
        {
            //target.Attack();
            Console.WriteLine("Attack");
        }

        public override void undo()
        {
            // Restore the attack with a prototype deep copy?
            Console.WriteLine("Restore Attack w/ Deep Copy");
        }
    }
}
