using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Iterators
{
    public abstract class Iterator : IEnumerator
    {
        public object Current => CurrentObject();

        public abstract object CurrentObject();

        public abstract int Key();

        public abstract bool MoveNext();

        public abstract void Reset();

    }
}
