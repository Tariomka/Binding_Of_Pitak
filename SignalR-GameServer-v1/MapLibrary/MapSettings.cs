using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SignalR_GameServer_v1.MapLibrary
{
    public class MapSettings
    {
        private static MapSettings _instance = null;

        public int MapWidth;
        public int MapHeight;

        private MapSettings()
        {
            MapWidth = 1000;
            MapHeight = 640;
        }

        public static MapSettings GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MapSettings();
            }
            return _instance;
        }
    }
}
