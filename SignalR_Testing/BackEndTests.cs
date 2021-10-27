using SignalR_GameServer_v1;
using System;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.Command;
using Xunit;


namespace SignalR_Testing
{
    public sealed class Setup : IDisposable
    {
        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        public Setup()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method

            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    public class BackendTests
    {
        [Fact]
        public void MapTest()
        {
            MapSettings settings = MapSettings.getInstance();

            Assert.Equal(640, settings.mapHeight);
            Assert.Equal(1000, settings.mapWidth);
        }

        [Fact]
        public void EmptyHeroTest()
        {
            int id = 10;
            string name = "Pataisymas";
            int health = 50;
            string ans = 0 + "  " + 0;

            Hero testHero = new Hero();

            Assert.Equal(ans, testHero.GetDetails());

            testHero.SetDetails(id, name, health, 20, 3);
            ans = id + " " + name + " " + health;

            Assert.Equal(ans, testHero.GetDetails());
        }

        [Fact]
        public void HeroTest()
        {
            int id = 1;
            string name = "Naujas";
            int health = 100;
            string ans = id + " " + name + " " + health;

            Hero testHero = new Hero(id, name, health, 10, 2);

            Assert.Equal(ans, testHero.GetDetails());
            
        }

        [Fact]
        void HeroMovementTest()
        {
            Hero testHero = new Hero();

            testHero.attack();
            testHero.endTurn();

            string upDir = "UP";
            string downDir = "DOWN";
            string rightDir = "RIGHT";
            string leftDir = "LEFT";
            string wrongDir = "Ups!";

            testHero.move(upDir);
            testHero.move(downDir);
            testHero.move(rightDir);
            testHero.move(leftDir);
            testHero.move(wrongDir);

            string msg = "test message";
            testHero.update(msg);
        }

        [Fact]
        
        public void PlayerAndItemTest()
        {
            Player player = new Player(1);
            Item item = new Item();
            Item item2 = new Item(1, "item2", "nullType", "effectiveless", 3, -1, -1);

            player.addItem(item);
            player.addItem(item2);
            
            Assert.Equal(2, player.getItemCount());

            int score = 200;
            player.increaseScore(score);

            Assert.Equal(score, player.getScore());

            int reducedScore = 50;
            player.reduceScore(reducedScore);

            Assert.Equal(score - reducedScore, player.getScore());
        }
    }
}
