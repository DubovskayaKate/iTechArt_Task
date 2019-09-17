using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Business.Services;
using MoneyManager.CompositionRoot;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Models;
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


            var categoryService = ConfigurationProvider.GetService<CategoryService>();
            categoryService.GetCategories();
            var category = categoryService.GetEntityById(30);

            var newCategory = new Category
            {
                ChildCategories = null,
                IsExpenses = false,
                Name = "Lotto",
                TransactionList = new List<Transaction>(),
                ParentCategory = category
            };
            category.ChildCategories = new List<Category> { newCategory };
            categoryService.Insert(newCategory);
            


            Console.WriteLine("Ready");
            Console.ReadKey(true);
        }
    }
}
