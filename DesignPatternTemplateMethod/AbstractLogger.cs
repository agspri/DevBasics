using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternTemplateMethod
{
    public abstract class AbstractLogger : ILogger
    {
        public LogLevels Levels { get; private set; }

        public ILogger NextLogger { get; set; }

        public AbstractLogger(LogLevels levels)
        {
            this.Levels = levels;
        }

        public void Log(string message, LogLevels level)
        {
            if (this.Levels.HasFlag(level))
                Console.WriteLine("ConsoleLogger: " + message);
            this.DoLog(message, level);
            this.NextLogger?.Log(message, level);
        }

        protected abstract void DoLog(string message, LogLevels level);
    }
}
