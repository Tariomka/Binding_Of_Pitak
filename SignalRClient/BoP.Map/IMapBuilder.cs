namespace BoP.MapLibrary
{
    public interface IMapBuilder
    {
        MapBuilder AddTile(string TileType);
        Map Build(int width, int height);
    }
}