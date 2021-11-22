using SOLID_Exercise.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }
        public IAppender Appender { get; }

        public void Critical(string dateTime, string message)
        {
            this.Appender.Append(dateTime, "Critical", message);
        }

        public void Error(string dateTime, string message)
        {
            this.Appender.Append(dateTime, "Error", message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Appender.Append(dateTime, "Fatal", message);
        }

        public void Info(string dateTime, string message)
        {
            this.Appender.Append(dateTime, "Info", message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Appender.Append(dateTime, "Warning", message);

        }
    }
}
