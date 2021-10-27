using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.Characters
{
    public class Player : Hero
    {
        private int id;
        private int score;

        public Player(int id) : base()
        {
            this.id = id;
            this.score = 0;
        }

        public void addItem(Item item)
        {
            this.equipItem(item);
        }

        public void increaseScore(int score)
        {
            this.score += score;
        }

        public void reduceScore(int score)
        {
            this.score -= score;
        }

        public int getScore()
        {
            return this.score;
        }
    }
}
