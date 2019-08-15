using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CoreTasks
{
    class StartUp
    {
        public Dictionary<string, List<string>> DictSettings = new Dictionary<string, List<string>>()
            {
                { "Info", new List<string>()},
                { "Warning", new List<string>()},
                { "Error", new List<string>()},
            };

        public StartUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            if (configuration.GetSection("Logging").Value == null)
            {
                DictSettings["Info"].Add("ConsoleLogger" );
                DictSettings["Warning"].Add("ConsoleLogger");
                DictSettings["Error"].Add("ConsoleLogger");
            }

            foreach (var child in configuration.GetSection("Logging").GetChildren())
            {
                foreach (var logLevel in child.GetSection("LogLevel").GetChildren())
                {
                    DictSettings[logLevel.Value].Add(child.Key);
                }
            }
        }
    }
}
