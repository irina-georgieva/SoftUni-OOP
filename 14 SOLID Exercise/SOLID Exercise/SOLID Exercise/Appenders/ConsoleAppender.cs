using SOLID_Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public void Append(string datetime, string reportLevel, string message)
        {
            Console.WriteLine(string.Format(this.Layout.Format, datetime, reportLevel, message));
        }
    }
}
