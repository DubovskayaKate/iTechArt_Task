using System;
using System.Collections.Generic;

namespace LoggerClassLibrary
{
    public class Logger: ILogger
    {
        Dictionary<string, ILogger> destinationNameToObjectDictionary = new Dictionary<string, ILogger>();
        Dictionary<string, List<string>> logLevelToDestinationsDictionary;

        private static Logger _instanceLogger;

        public static Logger CreateInstance()
        {
            if (_instanceLogger == null)
            {
                _instanceLogger = new Logger();
            }
            return _instanceLogger;
        }

        private Logger()
        {
            var startUp = new StartUp();
            destinationNameToObjectDictionary.Add("ConsoleLogger", new ConsoleLogger());
            destinationNameToObjectDictionary.Add("TextLogger", new TextLogger());
            logLevelToDestinationsDictionary = startUp.DictSettings;
        }

        public void Error(string message)
        {
            foreach (string destinationName in logLevelToDestinationsDictionary["Error"])
            {
                try
                {
                    var objLogger = destinationNameToObjectDictionary[destinationName];
                    objLogger.Error(message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{destinationName} is Not Implemented");
                } 
            }
        }

        public void Error(Exception ex)
        {
            Error(ex.Message);
        }

        public void Info(string message)
        {
            foreach (string destinationName in logLevelToDestinationsDictionary["Info"])
            {
                try
                { 
                    var objLogger = destinationNameToObjectDictionary[destinationName];
                    objLogger.Info(message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{destinationName} is Not Implemented");
                }
            }
        }

        public void Warning(string message)
        {
            foreach (string destinationName in logLevelToDestinationsDictionary["Warning"])
            {
                try
                { 
                    var objLogger = destinationNameToObjectDictionary[destinationName];
                    objLogger.Warning(message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{destinationName} is Not Implemented");
                }
            }
        }
    }
}
