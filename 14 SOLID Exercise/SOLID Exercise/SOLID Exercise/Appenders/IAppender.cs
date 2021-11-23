using SOLID_Exercise.Layouts;
using SOLID_Exercise.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public int Count { get; }

        public LogLevel ReportLevel { get; set; }

        void Append(string datetime, LogLevel reportLevel, string message);

        string GetAppenderInfo();
    }
}
