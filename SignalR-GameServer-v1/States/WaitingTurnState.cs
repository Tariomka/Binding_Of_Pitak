using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.States
{
    public class WaitingTurnState : State
    {
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void EndTurn()
        {
            this._creature.notifyServer("YOUR TURN");
            this._creature.TransitionTo(new ReadyState());
            this._creature.ResetRemainingSpeed();
        }

        public override void Move(string direction, bool flag)
        {
            this._creature.notifyServer("Can't move while not on your turn!");
        }

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
