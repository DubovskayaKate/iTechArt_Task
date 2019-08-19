using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LoggerClassLibrary
{
    class StartUp
    {
        public readonly Dictionary<LogLevel, List<string>> _logLevelToDestinationsDictionary = new Dictionary<LogLevel, List<string>>()
            {
                { LogLevel.Info, new List<string>()},
                { LogLevel.Warning, new List<string>()},
                { LogLevel.Error, new List<string>()},
            };

        private const string DefaultLogger = "ConsoleLogger";
        private const string SettingsFileName = "appsettings.json";
        private const string LoggingString = "Logging";

        public StartUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(SettingsFileName, optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();


            if (configuration.GetSection(LoggingString).GetChildren().Count() == 0)
            {
                _logLevelToDestinationsDictionary[LogLevel.Info].Add(DefaultLogger );
                _logLevelToDestinationsDictionary[LogLevel.Warning].Add(DefaultLogger);
                _logLevelToDestinationsDictionary[LogLevel.Error].Add(DefaultLogger);
            }


            /*configuration.GetSection(LoggingString).GetChildren().Select(child =>
                child.GetSection("LogLevel").GetChildren().Select(level =>
                    _logLevelToDestinationsDictionary[(LogLevel) Enum.Parse(typeof(LogLevel), level.Value)]
                        .Add(child.Key)));
                        */
            foreach (var child in configuration.GetSection(LoggingString).GetChildren())
            {
                foreach (var level in child.GetSection("LogLevel").GetChildren())
                {
                    _logLevelToDestinationsDictionary[(LogLevel)Enum.Parse(typeof(LogLevel), level.Value)].Add(child.Key);
                }
            }
        }
    }
}
