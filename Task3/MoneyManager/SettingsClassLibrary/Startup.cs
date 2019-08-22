using System;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SettingsClassLibrary
{
    public class Startup
    {
        public string ConnectionString { get; }

        private IConfigurationRoot Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            //services.AddSingleton<IMyService, MyService>();
        }

    }
}
