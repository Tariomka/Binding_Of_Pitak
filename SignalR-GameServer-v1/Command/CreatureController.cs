using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;

namespace SignalR_GameServer_v1.Command
{
    public class CreatureController
    {
        private List<ICommand> list;

        public CreatureController()
        {
            list = new List<ICommand>();
        }
        public void Run(ICommand command)
        {
            list.Add(command);
            command.execute();
        }

        public bool Undo()
        {
            int index = list.Count() - 1;

            if (index < 0)
                return false;

            ICommand command = list[index];
            list.RemoveAt(index);
            command.undo();
            return true;
        }
    }
}
