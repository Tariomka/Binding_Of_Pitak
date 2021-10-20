using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRClient.Observer;

namespace SignalRClient
{
    public abstract class Creature : IObserver
    {
        private string name;
        private int health;
        private int speed;
        private int actionCount;
        private int posX;
        private int posY;

        private Subject server;

        public Creature()
        {
            this.name = "";
            this.health = 0;
            this.speed = 0;
            this.actionCount = 0;
            this.posX = 0;
            this.posY = 0;
        }

        public Creature(string name, int health, int speed, int actionCount)
        {
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
            this.posX = 0;
            this.posY = 0;
        }

        public string getDetails()
        {
            return "";
        }

        public void setDetails(string name, int health, int speed, int actionCount)
        {
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
        }

        public void update(string msg)
        {
            Console.WriteLine(this.name + "received message: " + msg);
        }

        public void notifyServer(string result)
        {
            server.receiveFromClient(result);
        }

        public void setServer(Subject server)
        {
            throw new NotImplementedException();
        }

        public void move(string direction)
        {
            this.notifyServer(direction);
        }

        public void attack()
        {

        }

        public void endTurn()
        {

        }
    }
}
