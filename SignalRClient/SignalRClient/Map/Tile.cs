namespace SignalRClient.Map
{
    abstract class Tile
    {
        public abstract string type { get; }
        public abstract string image { get; } 
        public abstract int cost { get; set; }
    }
}
