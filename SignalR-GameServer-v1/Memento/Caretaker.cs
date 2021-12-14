using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Memento
{
    public class Caretaker
    {
        List<MementoClass> statesList;

        public Caretaker()
        {
            statesList = new List<MementoClass>();
        }

        public void add(MementoClass state)
        {
            statesList.Add(state);
        }

        public MementoClass get(int index)
        {
            //MementoClass restoreState = statesList.Get(index)
            MementoClass restoreState = statesList[index];
            //statesList.Remove(index);
            statesList.Remove(restoreState);
            return restoreState;
        }

        public int size()
        {
            return statesList.Count();
        }

    }
}
