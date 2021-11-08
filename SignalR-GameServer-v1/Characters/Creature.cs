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
        private int id;
        private string name;
        private int health;
        private int speed;
        private int actionCount;
        private int posX;
        private int posY;

        private Subject server;

        private CreatureController controller;

        protected Creature()
        {
            this.id = 0;
            this.name = "";
            this.health = 0;
            this.speed = 0;
            this.actionCount = 0;
            this.posX = 0;
            this.posY = 0;
            this.controller = new CreatureController();
        }

        protected Creature(int id, string name, int health, int speed, int actionCount)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.actionCount = actionCount;
            this.posX = 0;
            this.posY = 0;
            this.controller = new CreatureController();
        }

        public string GetDetails()
        {
            return id + " " + name + " " + health;
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
            Console.WriteLine(this.name + "received message: " + msg);
        }

        public void notifyServer(string result)
        {
            server.receiveFromClient(result);
        }

        public void setServer(Subject server)
        {
            this.server = server;
        }

        public void move(string direction)
        {
            ICommand movedir;
            if (direction == "LEFT") movedir = new MoveLeftCommand(this);
            else if (direction == "RIGHT") movedir = new MoveRightCommand(this);
            else if (direction == "UP") movedir = new MoveUpCommand(this);
            else if (direction == "DOWN") movedir = new MoveDownCommand(this);
            else movedir = null;


            if (movedir != null)
            {
                controller.Run(movedir);
                controller.Undo();
            }
            else Console.WriteLine("Something went wrong");
            

            //this.notifyServer(direction);
        }

        public void attack()
        {
            AttackCommand attack = new AttackCommand(this);
            controller.Run(attack);
            controller.Undo();
        }

        public void endTurn()
        {
            EndTurnCommand endturn = new EndTurnCommand(this);
            controller.Run(endturn);
            controller.Undo();
        }
    }
}
