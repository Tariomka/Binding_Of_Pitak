using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SignalR_GameServer_v1
{
    public class Settings
    {
        private static Settings instance = null;

        public int PlayerCount;
        public int MapWidth;
        public int MapHight;

        private Settings()
        {
            PlayerCount = 4;
            MapWidth = 1000;
            MapHight = 640;
        }

        public static Settings getInstance()
        {
            if (instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }
    }
}
