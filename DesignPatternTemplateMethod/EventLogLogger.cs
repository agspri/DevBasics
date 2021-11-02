using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternTemplateMethod
{
    class EventLogLogger : AbstractLogger
    {
        public EventLogLogger(LogLevels levels) : base(levels)
        {
        }

        protected override void DoLog(string message, LogLevels level)
        {
           // Todo
        }
    }
}
