using System;
using System.Linq;
using  Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Asset>();
            modelBuilder.Entity<Transaction>();
            modelBuilder.Entity<Category>();
        }

        public override int SaveChanges()
        {
            
            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}