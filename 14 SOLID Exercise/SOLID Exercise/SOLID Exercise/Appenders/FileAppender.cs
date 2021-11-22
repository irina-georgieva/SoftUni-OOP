using SOLID_Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class FileAppender : IAppender
    {
        private const string FilePath = "../../../Output/result.txt";
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public static string FilePath1 => FilePath;

        public ILayout Layout { get; }

        public void Append(string datetime, string reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, datetime, reportLevel, message);
            File.AppendAllText(FilePath, appendMessage);
        }
    }
}
