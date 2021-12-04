using SignalR_GameServer_v1.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.States
{
    public class ReadyState : State
    {
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void EndTurn()
        {
            this._creature.notifyServer("END TURN");
            this._creature.TransitionTo(new WaitingTurnState());
        }

        public override void Move(string direction, bool flag)
        {
            switch (direction)
            {
                case "LEFT":
                    this._creature.MovePosX(-40);
                    break;
                case "RIGHT":
                    this._creature.MovePosX(40);
                    break;
                case "UP":
                    this._creature.MovePosY(-40);
                    break;
                case "DOWN":
                    this._creature.MovePosY(40);
                    break;
                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }
            if (flag)
            {
                this._creature.UpdateRemainingSpeed(-1);
                this._creature.notifyServer(direction);
            }
            else
            {
                this._creature.UpdateRemainingSpeed(1);
                this._creature.notifyServer("Undone to ->" + direction);
            }
        }

        public override void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
