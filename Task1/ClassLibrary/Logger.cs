using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;

namespace LoggerClassLibrary
{

    public class Logger: ILogger
    {
        public Dictionary<LogLevel, List<ILogger>> LogLevelToDestinationListDictionary { get; }
        
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

            Dictionary<string, ILogger>  destinationNameToObjectDictionary = assembly.GetTypes()
                .Where(type => typeILogger.IsAssignableFrom(type) && type != typeILogger && type != typeof(Logger))
                .Select(type => new { Name = type.ToString(), Object = (ILogger)Activator.CreateInstance(type) })
                .ToDictionary(
                    anonymousObj => anonymousObj.Name.Substring(anonymousObj.Name.LastIndexOf('.') + 1), 
                    anonymousObj => anonymousObj.Object);

            LogLevelToDestinationListDictionary = startUp.LogLevelToDestinationsDictionary
                .Select(item => new
                {
                    Key = item.Key,
                    Value = item.Value
                        .Select(name => destinationNameToObjectDictionary.ContainsKey(name)? destinationNameToObjectDictionary[name] : null)
                        .Where(value => value != null)
                        .ToList()
                })
                .ToDictionary(obj => obj.Key, obj => obj.Value);
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
            foreach (var objLogger in LogLevelToDestinationListDictionary[logLevel])
            {
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
        }
    }
}
