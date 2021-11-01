using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternChainOfResponsibility
{
    public class ConsoleLogger : ILogger
    {
        public LogLevels Levels { get; private set; }

        public ILogger NextLogger { get; set; }

        public ConsoleLogger(LogLevels levels)
        {
            this.Levels = levels;
        }

        public void Log(string message, LogLevels level)
        {
            if (this.Levels.HasFlag(level))
                Console.WriteLine("ConsoleLogger: " + message);

            this.NextLogger?.Log(message, level);
        }
    }
}
