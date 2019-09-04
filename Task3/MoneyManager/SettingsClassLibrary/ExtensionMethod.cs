using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Business.Services;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.CompositionRoot
{
    public static class ExtensionMethod
    {
        public static void AddSingletons(this ServiceCollection services)
        {
            var startup = new Startup();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(startup.ConnectionString, x => x.MigrationsAssembly("MoneyManager"))
                .Options;

            services.AddSingleton<IApplicationContext>(new ApplicationContext(options));
            services.AddSingleton<DataGenerator>();
            services.AddSingleton<UserRepository>();
            services.AddSingleton<UserService>();
            services.AddSingleton<TransactionRepository>();
            services.AddSingleton<TransactionService>();
            services.AddSingleton<CategoryRepository>();
            services.AddSingleton<CategoryService>();
            services.AddSingleton<MixedService>();
            
        }
    }
}