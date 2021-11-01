using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternChainOfResponsibility
{
    [Flags]  // enum is treated as a bit field
    public enum LogLevels
    {
        Debug = 1,
        Information = 2,
        Warning = 4,
        Error = 8,
        Critical = 16,
        All = Debug | Information | Warning | Error | Critical
    }
    public interface ILogger
    {
        void Log(string message, LogLevels level);  // bei Interface sind all Methoden sowieso public
    }
}
