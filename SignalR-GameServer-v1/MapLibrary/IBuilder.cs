using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.MapLibrary
{
    public interface IBuilder
    {
        public void BuildGrassTile();
        public void BuildLavaTile();

        /// <summary>
        /// Random distribution of tiles
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        //public IBuilder AddTiles(TyleType tile);
        // var level = new LevelBuilder
        //         .AddTiles(Lava)
        //         .AddTiles(Grass)
        //         .Build();

        /// <summary>
        /// Specific distribution
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        //public IBuilder AddTiles(TyleType tile, double percent);

        // var level = new LevelBuilder
        //         .AddTiles(Lava, 10.0)
        //         .AddTiles(Grass, 70.0)
        //         .AddTiles(Boulder, 20.0)
        //         .Build();

        // level.GetNextTile();
    }
}
