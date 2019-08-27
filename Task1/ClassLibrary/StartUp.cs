using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LoggerClassLibrary
{
    class StartUp
    {
        public Dictionary<LogLevel, List<string>> LogLevelToDestinationsDictionary { get; private set; }

        private const string DefaultLogger = "ConsoleLogger";
        private const string SettingsFileName = "appsettings.json";
        private const string LoggingString = "Logging";

        public StartUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(SettingsFileName, optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            LogLevelToDestinationsDictionary =
                new Dictionary<LogLevel, List<string>>()
                {
                    {LogLevel.Info, new List<string>()},
                    {LogLevel.Warning, new List<string>()},
                    {LogLevel.Error, new List<string>()},
                };

            if (configuration.GetSection(LoggingString).GetChildren().Count() == 0)
            {
                LogLevelToDestinationsDictionary[LogLevel.Info].Add(DefaultLogger );
                LogLevelToDestinationsDictionary[LogLevel.Warning].Add(DefaultLogger);
                LogLevelToDestinationsDictionary[LogLevel.Error].Add(DefaultLogger);
            }


            /*configuration.GetSection(LoggingString).GetChildren().Select(child =>
                child.GetSection("LogLevel").GetChildren().Select(level =>
                    LogLevelToDestinationsDictionary[(LogLevel) Enum.Parse(typeof(LogLevel), level.Value)]
                        .Add(child.Key)));
                        */
            foreach (var child in configuration.GetSection(LoggingString).GetChildren())
            {
                foreach (var level in child.GetSection("LogLevel").GetChildren())
                {
                    LogLevel logLevel;
                    if (Enum.TryParse(level.Value, out logLevel))
                        LogLevelToDestinationsDictionary[logLevel].Add(child.Key);
                    else
                    {
                        Console.WriteLine($"Undefined logLevel {level.Value}. Possible logLevel values: Info, Warning, Error");
                    }
                }
            }
        }
    }
}
