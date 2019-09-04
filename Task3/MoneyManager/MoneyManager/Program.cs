using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.CompositionRoot;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager
{
    class Program
    {
        public static IServiceProvider ConfigurationProvider { get; private set; }

        static void Main(string[] args)
        {
            
            var services = new ServiceCollection();
            services.AddSingletons();
            ConfigurationProvider = services.BuildServiceProvider();


            var db = ConfigurationProvider.GetService<IApplicationContext>();
            var generator = ConfigurationProvider.GetService<DataGenerator>();
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
