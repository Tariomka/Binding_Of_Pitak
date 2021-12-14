using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Command;
using SignalR_GameServer_v1.Observer;
using SignalR_GameServer_v1.States;
using SignalR_GameServer_v1.Composite;


namespace SignalR_GameServer_v1.Characters
{
    public abstract class Creature : IObserver, ICloneable, GroupedCreature
    {
        private int id;
        private string name;
        private int health;
        private int speed;
        private int actionCount;
        private int posX;
        private int posY;

        private Subject server;
        private State _state;

        private int speedRemaining;

        #region constructor
        protected Creature()
        {
            this.id = 0;
            this.name = "";
            this.health = 0;
            this.speed = 0;
            this.actionCount = 0;
            this.posX = 0;
            this.posY = 0;
            this.speedRemaining = 0;
        }

        protected Creature(int id, string name, int health, int speed, int actionCount, int posx, int posy)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
            this.posX = posx;
            this.posY = posy;
            TransitionTo(new WaitingTurnState());
            ResetRemainingSpeed();
        }
        #endregion

        #region prototype
        //shallowcopy
        public Creature ShallowCopy()
        {
            return (Creature)this.MemberwiseClone();
        }

        //deepcopy
        public object Clone()
        {
            Creature copy = (Creature)this.MemberwiseClone();
            copy.server = server;
            return copy;
        }
        #endregion


        #region getters
        protected Subject GetServer() { return server; }

        public string GetDetails()
        {
            return this.id + " " + this.name + " " + this.health;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public virtual int GetSpeed()
        {
            return speed;
        }

        public int GetRemainingSpeed()
        {
            return speedRemaining;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public int GetActionCount()
        {
            return this.actionCount;
        }

        public int GetPosX()
        {
            return this.posX;
        }

        public int GetPosY()
        {
            return this.posY;
        }

        public string GetState()
        {
            return this._state.GetType().Name;
        }

        #endregion

        #region setters

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetDetails(int id, string name, int health, int speed, int actionCount)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
            TransitionTo(new WaitingTurnState());
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public void setServer(Subject server)
        {
            this.server = server;
        }

        public void SetPosX(int posx)
        {
            this.posX = posx;
        }

        public void SetPosY(int posY)
        {
            this.posY = posY;
        }

        #endregion


        public void update(string msg)
        {
            Console.WriteLine(this.name + " " + this.id + " " + " received message: " + msg);
        }

        public void notifyServer(string result)
        {
            server.receiveFromClient(result);
        }

        public virtual void Move(string direction, bool flag)
        {
            this._state.Move(direction, flag);
        }

        public void Attack()
        {
            // attack logic
            
        }

        public void EndTurn()
        {
            this._state.EndTurn();
        }

        public void TransitionTo(State state)
        {
            if (server != null)
            {
                this.notifyServer($"State - {state.GetType().Name}");
            }
            this._state = state;
            this._state.SetContext(this);
        }

        public void MovePosX(int posX)
        {
            this.posX += posX;
        }

        public void MovePosY(int posY)
        {
            this.posY += posY;
        }

        public void UpdateRemainingSpeed(int value)
        {
            this.speedRemaining += value;
        }

        public void ResetRemainingSpeed()
        {
            this.speedRemaining = this.speed;
        }

        public bool ReceiveDamage(int damage)
        {
            this.health -= damage;
            if (this.health > 0)
            {
                return true;
            }
            else
            {
                TransitionTo(new DeadState());
                this.health = 0;
                return false;
            }
        }

        public bool isCreature()
        {
            return true;
        }

        public List<GroupedCreature> GetCreatures()
        {
            Console.WriteLine("FLAG");
            throw new NotImplementedException();
        }
    }
}
