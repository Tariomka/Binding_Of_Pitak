using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    class DirtTile : Tile
    {
        private readonly string _type;
        private readonly string _image;
        private int _cost;
        private int _posX;
        private int _posY;

        public DirtTile(int cost)
        {
            _type = "Dirt";
            //string workingDirectory = Environment.CurrentDirectory;
            //string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            //string image = currentDir + @"\Resources\lava.png";
            //_image = image;
            _cost = cost;
        }
        public override void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public override string type
        {
            get { return type; }
        }

        public override string image
        {
            get { return _image; }
        }

        public override int cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public override int posX
        {
            get { return _posX; }
        }
        public override int posY
        {
            get { return _posY; }
        }
    }
}
