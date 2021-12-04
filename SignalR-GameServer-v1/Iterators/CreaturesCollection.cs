using SignalR_GameServer_v1.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Iterators
{
    public class CreaturesCollection : IteratorAggregate
    {
        private List<Hero> _creatures = new List<Hero>();
        private bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<Hero> GetCreatures()
        {
            return _creatures;
        }

        public int GetCreaturesCount()
        {
            return _creatures.Count;
        }

        public Hero GetCreature(int pos)
        {
            return _creatures[pos];
        }

        public void Add(Hero creature)
        {
            this._creatures.Add(creature);
        }

        public Hero Find(int id)
        {
            return this._creatures.Find(x => x.GetId() == id);
        }

        public Hero FindNext(int id)
        {
            var current = this._creatures.FindIndex(x => x.GetId() == id);
            var creature = this._creatures[current == this._creatures.Count-1 ? 0 : current + 1];
            return creature;
        }

        public override IEnumerator GetEnumerator()
        {
            return new TurnOrderIterator(this, _direction);
        }
    }
}
