using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
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

            var db = new ApplicationContext(options);

            var generator = new DataGenerator();

            if (db.Users.Any()|| db.Categories.Any())
            {
                generator.GenarateData(ref db);
                db.SaveChanges();
            }

            

            Console.WriteLine("Ready");
            Console.ReadKey(true);
        }
    }
}
