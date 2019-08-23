using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Repositories;
using SettingsClassLibrary;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            var services = new ServiceCollection();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(startup.ConnectionString, x => x.MigrationsAssembly("MoneyManager"))
                .Options;


            services.AddSingleton<IApplicationContext>(new ApplicationContext(options));
            services.AddSingleton<DataGenerator>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();


            var t = serviceProvider.GetService<IApplicationContext>();
            var generator = serviceProvider.GetService<DataGenerator>();


            var db = new ApplicationContext(options);

            if (!db.Users.Any()|| !db.Categories.Any())
            {
                generator.GenerateData();
                db.SaveChanges();
            }

            

            Console.WriteLine("Ready");
            Console.ReadKey(true);
        }
    }
}
