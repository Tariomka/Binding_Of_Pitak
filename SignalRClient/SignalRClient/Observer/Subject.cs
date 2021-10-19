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

        public void attach ( IObserver unit )
        {

        }

        public void deattach( IObserver unit )
        {

        }

        public void notifyAll( string msg)
        {
            foreach (IObserver unit in list)
            {
                unit.update(msg);
            }
        }


        public void receiveFromClient( string msg )
        {
            this.notifyAll(msg);
        }
    }
}
