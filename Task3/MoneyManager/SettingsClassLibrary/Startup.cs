using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyManager.CompositionRoot
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
        }

    }
}
