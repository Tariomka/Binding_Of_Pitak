using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Command
{
    public class EndTurnCommand : ICommand
    {
        public EndTurnCommand(Creature target) : base(target)
        {

        }

        public override void execute()
        {
            target.EndTurn();
        }

        public override void undo()
        {
            // Restore the turn with a prototype deep copy?
            Console.WriteLine("Undo EndTurn");
        }
    }
}
