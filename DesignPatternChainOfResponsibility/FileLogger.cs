using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternChainOfResponsibility
{
    public class FileLogger : ILogger
    {
        public string FileName { get; private set; }
        public LogLevels Levels { get; private set; }

        public ILogger NextLogger { get; set; }

        public FileLogger(LogLevels levels, string fileName)
        {
            this.FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            this.Levels = levels;
        }
        public void Log(string message, LogLevels level)
        {
            if (this.Levels.HasFlag(level))
                System.IO.File.AppendAllLines(this.FileName, new string[] { message });

            this.NextLogger?.Log(message, level);
        }
    }
}
