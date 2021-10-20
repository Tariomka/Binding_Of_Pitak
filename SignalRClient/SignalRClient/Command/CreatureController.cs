using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Command
{
    public class CreatureController
    {
        private List<ICommand> list = new List<ICommand>();

        public void run(ICommand command)
        {
            list.Add(command);
            command.execute();
        }

        public void undo()
        {
            int index = list.Count() - 1;
            ICommand command = list[index];
            list.RemoveAt(index);
            command.undo();
        }
    }
}
