using System;
using System.Collections.Generic;
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
            

            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Users.Add(new User {Balance = 23, Name = "Kate1", Email = "q@gmail.com", Assets = new List<Asset>()});
                db.SaveChanges();
                var objUser = db.Users.Where(user => user.UserId == 2).First();
                var asset = new Asset{Balance = 30, Name = "cash", User = objUser, };
                objUser.Assets.Add(asset);
                db.SaveChanges();
            }

            Console.WriteLine("Ready");
            Console.ReadKey(true);
        }
    }
}
