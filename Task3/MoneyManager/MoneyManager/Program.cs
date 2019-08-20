using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using MoneyManagerClassLibrary;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString, x => x.MigrationsAssembly("MoneyManager"))
                .Options;
            

            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Users.Add(new User{Email = "y@gmail.com", Balance = 40, Name = "Kate1", Assets = new List<Asset>()});
                db.SaveChanges();
            }

            Console.WriteLine("Ready");
            Console.ReadKey(true);
        }
    }
}
