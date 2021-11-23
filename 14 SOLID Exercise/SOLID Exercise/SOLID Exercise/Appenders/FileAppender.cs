using SOLID_Exercise.Layouts;
using SOLID_Exercise.LogFiles;
using SOLID_Exercise.ReportLevel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";
        
        public FileAppender(ILayout layout, ILogFile file)
            :base(layout)
        {
            this.LogFile = file;
        }
        public ILogFile LogFile { get; }

        public static string FilePath1 => FilePath;

        public override void Append(string datetime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, datetime, reportLevel, message);

            LogFile.Write(appendMessage);

            this.Count++;

            File.AppendAllText(FilePath, appendMessage + Environment.NewLine);
        }

        public override string GetAppenderInfo()
        
            => $"{base.GetAppenderInfo()}, File size: {this.LogFile.Size}";
        
    }
}
