using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.MapLibrary
{
    public class Level1Builder : IBuilder
    {
        private Map _map = new Map();
        private GrassFactory grassFactory = new GrassFactory(1);
        private LavaFactory LavaFactory = new LavaFactory(1);
        public Level1Builder() 
        {
            this.Reset();
        }

        private void Reset()
        {
            this._map = new Map();
        }
        public void BuildGrassTile()
        {
            this._map.AddTile(grassFactory.GetTile());
        }
        public void BuildLavaTile()
        {
            this._map.AddTile(LavaFactory.GetTile());
        }
    }
}
