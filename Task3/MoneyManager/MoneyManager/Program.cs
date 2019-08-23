using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Business.Services;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;
using SettingsClassLibrary;

namespace MoneyManager
{
    class Program
    {
        public static IServiceProvider ConfigurationProvider { get; private set; }

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
            services.AddSingleton<UserRepository<User>>();
            services.AddSingleton<UserService>();

            ConfigurationProvider = (IServiceProvider)services.BuildServiceProvider();


            var db = ConfigurationProvider.GetService<IApplicationContext>();
            var generator = ConfigurationProvider.GetService<DataGenerator>();
            if (!db.Users.Any()|| !db.Categories.Any())
            {
                generator.GenerateData();
                db.SaveChanges();
            }

            var userService = ConfigurationProvider.GetService<UserService>();

            var list = userService.GetAllUser();

            foreach (var user in list)
            {
                Console.WriteLine(user);
            }

            var findedUser = userService.GetUserById(86);
            findedUser.Name = "Kolya";
            userService.Update(findedUser);

            list = userService.GetAllUser();

            foreach (var user in list)
            {
                Console.WriteLine(user);
            }



            Console.WriteLine("Ready");
            Console.ReadKey(true);
        }
    }
}
