using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternTemplateMethod
{
    public class FileLogger : AbstractLogger
    {
        public string FileName { get; private set; }
      
        public FileLogger(LogLevels levels, string fileName) : base(levels)
        {
            this.FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }
       protected override void DoLog(string message, LogLevels level)
        {
                System.IO.File.AppendAllLines(this.FileName, new string[] { message });
        }
    }
}
