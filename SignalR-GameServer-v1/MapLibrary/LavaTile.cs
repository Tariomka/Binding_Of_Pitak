using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.MapLibrary
{
    class LavaTile : Tile
    {
        private readonly string _type;
        private readonly string _image;
        private int _cost;

        public LavaTile(int cost)
        {
            _type = "Grass";
            string workingDirectory = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(workingDirectory).Parent.FullName;
            string image = currentDir + @"\Resources\lava.png";
            _image = image;
            _cost = cost;
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
    }
}
