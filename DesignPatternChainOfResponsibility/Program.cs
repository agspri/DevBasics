using System;

namespace DesignPatternChainOfResponsibility
{
    class Program
    {
        const string FILE_NAME = @"D:\tmp\Logs\log.txt";
        static void Main(string[] args)
        {
            FileLogger fileLogger = new FileLogger(LogLevels.Information | LogLevels.Warning | LogLevels.Error, FILE_NAME);
            ConsoleLogger consoleLogger = new ConsoleLogger(LogLevels.All);
            EventLogLogger eventLogLogger = new EventLogLogger(LogLevels.Warning | LogLevels.Error | LogLevels.Critical);
            consoleLogger.NextLogger = fileLogger;
            fileLogger.NextLogger = eventLogLogger;

            consoleLogger.Log("Program started", LogLevels.Debug);
            consoleLogger.Log("Warning", LogLevels.Warning);

            Console.ReadKey();
        }
    }
}
