using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternTemplateMethod
{
    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(LogLevels levels) : base(levels) { }

        public ConsoleLogger() : base(LogLevels.Debug) { }

        protected override void DoLog(string message, LogLevels level)
        {
            Console.WriteLine(message);
        }
    }
}
