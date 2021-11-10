using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_GameServer_v1.Command;
using SignalR_GameServer_v1.Observer;

namespace SignalR_GameServer_v1.Characters
{
    public abstract class Creature : IObserver
    {
        private string id;
        private int name;
        private int health;
        private int speed;
        private int actionCount;
        private int posX;
        private int posY;

        private Subject server;

        protected Creature()
        {
            this.id = "";
            this.name = 0;
            this.health = 0;
            this.speed = 0;
            this.actionCount = 0;
            this.posX = 0;
            this.posY = 0;
        }

        protected Creature(string id, int name, int health, int speed, int actionCount, int posx, int posy)
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
            return id + " " + name + " " + health;
        }

        public string GetId()
        {
            return this.id;
        }

        public int GetName()
        {
            return this.name;
        }

        public void SetName(int name)
        {
            this.name = name;
        }

        public virtual int GetSpeed()
        {
            return speed;
        }

        public void SetDetails(string id, int name, int health, int speed, int actionCount)
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
            Console.WriteLine("Player " + this.name + " received message: " + msg);
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
