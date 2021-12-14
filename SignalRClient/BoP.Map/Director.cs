using System;
using System.Collections.Generic;
using System.Text;

namespace BoP.MapLibrary
{
    public class Director
    {
        private IMapBuilder _builder;
        public IMapBuilder Builder
        {
            set { _builder = value; }
        }
        public void BuildGrassMap()
        {
            this._builder.BuildGrassTile();
        }
        public void BuildMixedMap()
        {
            this._builder.BuildGrassTile();
            this._builder.BuildLavaTile();
            this._builder.BuildDirtTile();
            this._builder.AddItem();
        }
    }
}
