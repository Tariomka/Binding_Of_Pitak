using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public abstract class Creature
    {
        private string id { get; set; }
        private int health { get; set; }
        private int speed { get; set; }
        private int actionCount { get; set; }
        private int posX { get; set; }
        private int posY { get; set; }

        public virtual int GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public virtual string GetId()
        {
            return id;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public virtual int GetPosX()
        {
            return posX;
        }

        public void SetPostX(int posX)
        {
            this.posX = posX;
        }

        public virtual int GetPosY()
        {
            return posY;
        }

        public void SetPostY(int posY)
        {
            this.posY = posY;
        }


    }
}
