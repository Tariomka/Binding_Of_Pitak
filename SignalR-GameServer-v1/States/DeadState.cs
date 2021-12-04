using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.States
{
    public class DeadState : State
    {
        public override void Attack()
        {
            this._creature.notifyServer("Can't attack while dead!");
        }

        public override void EndTurn()
        {
            this._creature.notifyServer("Can't end turn while dead!");
        }

        public override void Move(string direction, bool flag)
        {
            this._creature.notifyServer("Can't move while dead!");
        }

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
