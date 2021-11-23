using SOLID_Exercise.Appenders;
using SOLID_Exercise.Layouts;
using SOLID_Exercise.Loggers;
using System;
using SOLID_Exercise.LogFiles;
using SOLID_Exercise.ReportLevel;
using SOLID_Exercise.Factory;

namespace SOLID_Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            
            ILogger logger = new Logger();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split();

                string type = appenderInfo[0];
                string layoutType = appenderInfo[1];

                IAppender appender = null;
                ILayout layout = layoutFactory.Create(layoutType);

                

                if (layoutType == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == "XmlLayout")
                {
                    layout = new XmlLayout();
                }

                if (type == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (type == "FileAppender")
                {
                    ILogFile logFile = new LogFile();
                    appender = new FileAppender(layout, logFile);
                }

                if (appenderInfo.Length == 3)
                {
                    bool isValidLogLevel = Enum.TryParse
                        (appenderInfo[2], ignoreCase: true, out LogLevel logLevel);

                    if (isValidLogLevel)
                    {
                        appender.ReportLevel = logLevel;
                    }
                }

                logger.Appenders.Add(appender);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] messageInfo = input.Split('|');

                string logLevel = messageInfo[0];
                string date = messageInfo[1];
                string message = messageInfo[2];

                bool isValidLogLevel = Enum.TryParse
                        (logLevel, ignoreCase: true, out LogLevel messagelogLevel);

                if (!isValidLogLevel)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (messagelogLevel == LogLevel.Info)
                {
                    logger.Info(date, message);
                }
                else if (messagelogLevel == LogLevel.Warning)
                {
                    logger.Warning(date, message);
                }
                else if (messagelogLevel == LogLevel.Error)
                {
                    logger.Error(date, message);
                }
                else if (messagelogLevel == LogLevel.Critical)
                {
                    logger.Critical(date, message);
                }
                else if (messagelogLevel == LogLevel.Fatal)
                {
                    logger.Fatal(date, message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            Console.WriteLine(logger.GetLoggerInfo());



        }
    }
}
