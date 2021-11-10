using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    public abstract class AbstractFactory
    {
        public abstract Heal createHeal(int id, int posX, int posY);
        public abstract Gun createGun(int id, int posX, int posY);
        public abstract Energy createEnergy(int id, int posX, int posY);
    }

    public class CommonItemsFactory : AbstractFactory
    {
        public override Heal createHeal(int id, int posX, int posY)
        {
            return new MinorHeal(id, posX, posY);
        }

        public override Gun createGun(int id, int posX, int posY)
        {
            return new BlueGun(id, posX, posY);
        }

        public override Energy createEnergy(int id, int posX, int posY)
        {
            return new BlueEnergy(id, posX, posY);
        }
    }

    public class RareItemsFactory : AbstractFactory
    {
        public override Heal createHeal(int id, int posX, int posY)
        {
            return new MajorHeal(id, posX, posY);
        }

        public override Gun createGun(int id, int posX, int posY)
        {
            return new GreenGun(id, posX, posY);
        }

        public override Energy createEnergy(int id, int posX, int posY)
        {
            return new GreenEnergy(id, posX, posY);
        }
    }
}
