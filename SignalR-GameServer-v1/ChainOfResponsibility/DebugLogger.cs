using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_GameServer_v1.ChainOfResponsibility
{
    public class DebugLogger : AbstractLogger
    {
        public DebugLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            Console.WriteLine("File::Logger: " + message);
        }
    }
}
