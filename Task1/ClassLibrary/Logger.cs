using System;
using System.Collections.Generic;

namespace LoggerClassLibrary
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
    public class Logger: ILogger
    {
        Dictionary<string, ILogger> destinationNameToObjectDictionary = new Dictionary<string, ILogger>();
        Dictionary<LogLevel, List<string>> logLevelToDestinationsDictionary;
        
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
            logLevelToDestinationsDictionary = startUp._logLevelToDestinationsDictionary;
        }

        public void Error(string message)
        {
            LogInformation(message, LogLevel.Error);
        }

        public void Error(Exception ex)
        {
            Error(ex.Message);
        }

        public void Info(string message)
        {
            LogInformation(message, LogLevel.Info);
        }

        public void Warning(string message)
        {
            LogInformation(message, LogLevel.Warning);
        }

        private void LogInformation(string message, LogLevel logLevel)
        {
            foreach (string destinationName in logLevelToDestinationsDictionary[logLevel])
            {
                try
                {
                    ILogger objLogger = destinationNameToObjectDictionary[destinationName];
                    switch (logLevel)
                    {
                        case LogLevel.Error:
                            objLogger.Error(message);
                            break;
                        case LogLevel.Info:
                            objLogger.Info(message);
                            break;
                        case LogLevel.Warning:
                            objLogger.Warning(message);
                            break;
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"{destinationName} is Not Implemented");
                }
            }
        }
    }
}
