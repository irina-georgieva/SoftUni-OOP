using SOLID_Exercise.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public interface ILogger
    {
        public List<IAppender> Appenders { get; }

        string GetLoggerInfo();

        public void Info(string dateTime, string message);
        public void Warning(string dateTime, string message);
        public void Error(string dateTime, string message);
        public void Critical(string dateTime, string message);
        public void Fatal(string dateTime, string message);
    }
}
