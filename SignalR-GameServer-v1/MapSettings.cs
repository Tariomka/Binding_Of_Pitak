﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SignalR_GameServer_v1
{
    public class MapSettings
    {
        public static int HorizontalTiles = 25;
        public static int VerticalTiles = 16;

        private static MapSettings instance = null;

        public int mapWidth;
        public int mapHeight;

        private MapSettings()
        {
            mapWidth = 1000;
            mapHeight = 640;
        }

        public static MapSettings getInstance()
        {
            if (instance == null)
            {
                instance = new MapSettings();
            }
            return instance;
        }
    }
}
