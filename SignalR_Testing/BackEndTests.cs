using SignalR_GameServer_v1;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SignalR_GameServer_v1.Characters;
using SignalR_GameServer_v1.Command;
using SignalR_GameServer_v1.Hubs;
using SignalR_GameServer_v1.Observer;
using SignalR_GameServer_v1.MapLibrary;
using Xunit;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace SignalR_Testing
{
    [ExcludeFromCodeCoverage]
    public class BackendTests : IDisposable
    {
        private bool disposedValue;
        private int id;
        private string name;
        private int health;
        private Mock<IConfiguration> config;
        private Startup start;
        private Mock<IHubContext<GameHub>> gameHubMock;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    config = null;
                    start = null;
                    gameHubMock = null;

                    id = 0;
                    name = "";
                    health = 0;
                }
                disposedValue = true;
            }
        }

        public BackendTests()
        {
            config = new Mock<IConfiguration>();
            start = new Startup(config.Object);
            gameHubMock = new Mock<IHubContext<GameHub>>();

            id = 10;
            name = "Pataisymas";
            health = 50;

            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


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
            string ans = id + " " + name + " " + health;

            Hero testHero = new Hero(id, name, health, 10, 2);

            Assert.Equal(ans, testHero.GetDetails());

        }

        [Fact]
        public void HeroMovementTest()
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
            Item item2 = new Item(id, "item2", "nullType", "effectiveless", 3, -1, -1);

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

        [Fact]
        public void ObserverMockTest()
        {
            Hero testHero = new Hero();
            Server server = new Server();

            var observer = new Mock<IObserver>();

            server.attach(observer.Object);

            testHero.setServer(server);

            testHero.notifyServer("bandymas");

            server.deattach(observer.Object);

        }

        [Fact]
        public void HubMapTest()
        {
            string message = "Hello";

            Hero hero = new Hero(id, name, health, 10, 2);
            GameHub hub = new GameHub();
            var uid = new Guid();

            Map map = new Map(0);
            var maplayout = map.GetLayout();

            // Tasks
            //--------------------------------------------
            hub.JoinGame(uid);

            hub.SendMessage(hero.GetName(), message);
            hub.SendCoordinates(hero.GetId(), "LEFT");

            hub.GetMapSize();
            hub.SendMapLayout(maplayout);
            //--------------------------------------------
        }

        [Fact]
        public void StartupTest()
        {
            var app = new Mock<IApplicationBuilder>();
            var env = new Mock<IWebHostEnvironment>();
            var ser = new Mock<IServiceCollection>();

            Startup start = new Startup(config.Object);

            Assert.Equal(config.Object, start.Configuration);
            //start.ConfigureServices(ser.Object);
            //start.Configure(app.Object, env.Object);
        }


        //[Fact]
        //public void HubMessageTest()
        //{
        //    string message2 = "Hello to Group";

        //    Hero hero = new Hero(id, name, health, 10, 2);
        //    GameHub hub = new GameHub();
        //    var uid = new Guid();

        //    var listas = new Dictionary<string, int>();

        //    hub.PlayerJoined(hero.GetId());
        //    hub.SendNewIdReceived(hero.GetId(), listas);
        //    hub.SendMessageTogroup(message2);

        //}

    }
}
