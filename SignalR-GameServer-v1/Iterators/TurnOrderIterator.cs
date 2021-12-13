using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Iterators
{
    public class TurnOrderIterator : Iterator
    {
        private CreaturesCollection _collection;
        private int _position = -1;
        private bool _reverse = false;

        public TurnOrderIterator(CreaturesCollection collection, bool reverseDirection = false)
        {
            this._collection = collection;
            this._reverse = reverseDirection;

            if (reverseDirection)
            {
                this._position = collection.GetCreaturesCount();
            }
        }

        public override object CurrentObject()
        {
            return this._collection.GetCreature(_position);
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.GetCreaturesCount())
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._collection.GetCreaturesCount() - 1 : 0;
        }
    }
}
