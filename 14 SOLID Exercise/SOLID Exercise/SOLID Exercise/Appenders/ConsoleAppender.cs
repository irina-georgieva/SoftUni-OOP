using SOLID_Exercise.Layouts;
using SOLID_Exercise.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
           
        }

        public override void Append(string datetime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, datetime, reportLevel, message);

            this.Count++;
            
            Console.WriteLine(appendMessage);
        }
    }
}
