using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.States;

namespace SignalR_GameServer_v1.Composite
{
    public class Division : GroupedCreature
    {
        private int _playerIndicator;
        private List<GroupedCreature> _creatureList = new List<GroupedCreature>();
        public void Add(GroupedCreature creature)
        {
            _creatureList.Add(creature);
        }
        public void Remove(GroupedCreature creature)
        {
            _creatureList.RemoveAt(_creatureList.IndexOf(creature));
        }

        public void SetPlayer(int id) 
        {
            _playerIndicator = id;
        }

        public int GetPlayer()
        {
            return _playerIndicator;
        }

        public int GetCreatureCount()
        {
            return _creatureList.Count;
        }
        
        public List<GroupedCreature> GetCreatures()
        {
            return _creatureList;
        }

        public void Move(string direction, bool flag)
        {
            foreach (var creature in _creatureList)
            {
                creature.Move(direction, flag);
            }
        }

        public void TransitionTo(State state)
        {
            foreach (var creature in _creatureList)
            {
                creature.TransitionTo(state);
            }
        }

        public bool isCreature()
        {
            return false;
        }

        public int GetPosX()
        {
            throw new NotImplementedException();
        }

        public int GetPosY()
        {
            throw new NotImplementedException();
        }
    }
}
