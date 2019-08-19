using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            var typeILogger = typeof(ILogger);
            Assembly assembly = typeof(ILogger).Module.Assembly;
            destinationNameToObjectDictionary = assembly.GetTypes()
                .Where(type => typeILogger.IsAssignableFrom(type) && type != typeILogger && type != typeof(Logger))
                .Select(type => new { Name = type.ToString(), Object = (ILogger)Activator.CreateInstance(type) })
                .ToDictionary(k => k.Name.Substring(k.Name.LastIndexOf('.') + 1), i => i.Object); 
            
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
