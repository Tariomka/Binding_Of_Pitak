using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BoP.MapLibrary
{
    public abstract class Item
    {
        public int id;
        public string name;
        public string type;
        public string image;
        public int posX;
        public int posY;

        public abstract void PickupEffect();


        public Item()
        {
            this.id = 0;
            this.name = "";
            this.type = "";
            this.posX = 0;
            this.posY = 0;
        }

        public Item(int id, string name, string type, int posX, int posY)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.posX = posX;
            this.posY = posY;
        }
    }
    public class Heal : Item
    {
        public virtual int Hp { get; protected set; }

        public override void PickupEffect()
        {
        }
    }
    public class MinorHeal : Heal
    {
        public MinorHeal(int id, int posX, int posY)
        {
            this.id = id;
            this.name = "minorheal";
            this.type = "Heal";
            this.posX = posX;
            this.posY = posY;
            this.Hp = 10;
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\minorheal.png";
            this.image = image;
        }
    }
    public class MajorHeal : Heal
    {
        public MajorHeal(int id, int posX, int posY)
        {
            this.id = id;
            this.name = "majorheal";
            this.type = "Heal";
            this.posX = posX;
            this.posY = posY;
            this.Hp = 50;
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\majorheal.png";
            this.image = image;
        }
    }
    public class Gun : Item
    {
        public virtual int Damage { get; protected set; }
        public virtual int Ammo { get; protected set; }

        public override void PickupEffect()
        {
        }
    }
    public class BlueGun : Gun
    {
        public BlueGun(int id, int posX, int posY)
        {
            this.id = id;
            this.name = "bluegun";
            this.type = "Gun";
            this.posX = posX;
            this.posY = posY;
            this.Damage = 20;
            this.Ammo = 5;
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\bluegun.png";
            this.image = image;
        }
    }
    public class GreenGun : Gun
    {
        public GreenGun(int id, int posX, int posY)
        {
            this.id = id;
            this.name = "greengun";
            this.type = "Gun";
            this.posX = posX;
            this.posY = posY;
            this.Damage = 5;
            this.Ammo = 15;
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\greengun.png";
            this.image = image;
        }
    }
    public class Energy : Item
    {
        public virtual int Points { get; protected set; }

        public override void PickupEffect()
        {

        }
    }
    public class BlueEnergy : Energy
    {
        public BlueEnergy(int id, int posX, int posY)
        {
            this.id = id;
            this.name = "blueenergy";
            this.type = "Energy";
            this.posX = posX;
            this.posY = posY;
            this.Points = 100;
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\blueenergy.png";
            this.image = image;
        }
    }

    public class GreenEnergy : Energy
    {
        public GreenEnergy(int id, int posX, int posY)
        {
            this.id = id;
            this.name = "greenenergy";
            this.type = "Energy";
            this.posX = posX;
            this.posY = posY;
            this.Points = 200;
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\greenenergy.png";
            this.image = image;
        }
    }
}
