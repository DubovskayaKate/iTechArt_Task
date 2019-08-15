using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerClassLibrary
{
    public class Logger: ILogger
    {
        Dictionary<string, ILogger> LogDestintion = new Dictionary<string, ILogger>();
        Dictionary<string, List<string>> DictSettings;


        public Logger(Dictionary<string, List<string>> settings)
        {
            LogDestintion.Add("ConsoleLogger", new ConsoleLogger());
            LogDestintion.Add("TextLogger", new TextLogger());
            DictSettings = settings;
        }

        public void Error(string message)
        {
            foreach (string nameOfLogDestination in DictSettings["Error"])
            {
                try
                {
                    var objLogger = LogDestintion[nameOfLogDestination];
                    objLogger.Error(message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{nameOfLogDestination} is Not Implemented");
                } 
            }
        }

        public void Error(Exception ex)
        {
            Error(ex.Message);
        }

        public void Info(string message)
        {
            foreach (string nameOfLogDestination in DictSettings["Info"])
            {
                try
                { 
                    var objLogger = LogDestintion[nameOfLogDestination];
                    objLogger.Info(message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{nameOfLogDestination} is Not Implemented");
                }
            }
        }

        public void Warning(string message)
        {
            foreach (string nameOfLogDestination in DictSettings["Warning"])
            {
                try
                { 
                    var objLogger = LogDestintion[nameOfLogDestination];
                    objLogger.Warning(message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{nameOfLogDestination} is Not Implemented");
                }
            }
        }
    }
}
