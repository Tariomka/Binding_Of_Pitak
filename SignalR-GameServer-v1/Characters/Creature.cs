using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Command;
using SignalR_GameServer_v1.Observer;

namespace SignalR_GameServer_v1.Characters
{
    public abstract class Creature : IObserver, ICloneable
    {
        private int id;
        private string name;
        private int health;
        private int speed;
        private int actionCount;
        private int posX;
        private int posY;

        private Subject server;

        protected Creature()
        {
            this.id = 0;
            this.name = "";
            this.health = 0;
            this.speed = 0;
            this.actionCount = 0;
            this.posX = 0;
            this.posY = 0;
        }

        protected Subject GetServer() { return server; }

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

        protected Creature(int id, string name, int health, int speed, int actionCount, int posx, int posy)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
            this.posX = posx;
            this.posY = posy;
        }

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

        public void SetName(string name)
        {
            this.name = name;
        }

        public virtual int GetSpeed()
        {
            return speed;
        }

        public void SetDetails(int id, string name, int health, int speed, int actionCount)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public void update(string msg)
        {
            Console.WriteLine(this.name + " " + this.id + " " + " received message: " + msg);
        }

        public void notifyServer(string result)
        {
            server.receiveFromClient(result);
        }

        public void setServer(Subject server)
        {
            this.server = server;
        }

        public virtual void Move(string direction)
        {
            if (direction == "LEFT") MovePosX(-40 * this.GetSpeed());
            else if (direction == "RIGHT") MovePosX(40 * this.GetSpeed());
            else if (direction == "UP") MovePosY(-40 * this.GetSpeed());
            else if (direction == "DOWN") MovePosY(40 * this.GetSpeed());
            this.notifyServer(direction);
        }

        public void Attack()
        {
            // attack logic
            
        }

        public void EndTurn()
        {
            //end turn logic
            
        }

        public int GetPosX()
        {
            return this.posX;
        }

        public void SetPosX(int posx)
        {
            this.posX = posx;
        }

        public int GetPosY()
        {
            return this.posY;
        }

        public void SetPosY(int posY)
        {
            this.posY = posY;
        }

        public void MovePosX(int posX)
        {
            this.posX += posX;
        }

        public void MovePosY(int posY)
        {
            this.posY += posY;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public int GetActionCount()
        {
            return this.actionCount;
        }
    }
}
