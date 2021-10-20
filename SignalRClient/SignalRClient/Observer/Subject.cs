using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.Observer
{
    public class Subject
    {
        private List<IObserver> list = new List<IObserver>();

        public void attach ( IObserver creature )
        {
            list.Add(creature);
            creature.setServer(this);
        }

        public void deattach(IObserver creature)
        {

        }

        public void notifyAll(string msg)
        {
            foreach (IObserver creature in list)
            {
                creature.update(msg);
            }
        }


        public void receiveFromClient(string msg)
        {
            this.notifyAll(msg);
        }
    }
}
