using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternChainOfResponsibility
{
    class EventLogLogger : ILogger
    {
        public LogLevels Levels { get; private set; }
        public ILogger NextLogger { get; set; }

        public EventLogLogger(LogLevels levels)
        {
            this.Levels = levels;
        }

        public void Log(string message, LogLevels level)
        {
            if (this.Levels.HasFlag(level))
                Console.WriteLine("EventLogLogger: " + message);

            this.NextLogger?.Log(message, level);
        }
    }
}
