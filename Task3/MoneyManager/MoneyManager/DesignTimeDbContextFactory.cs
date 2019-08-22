﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace MoneyManager
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = "Data Source=WSC-160-71\\SQLEXPRESS;Initial Catalog=MoneyManager;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("MoneyManager"));
            return new ApplicationContext(builder.Options);
        }
    }
}
