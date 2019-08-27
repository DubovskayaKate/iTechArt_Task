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
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Asset>().ToTable("Assets");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }

        public override int SaveChanges()
        {
            /*var k = ChangeTracker.AutoDetectChangesEnabled;

            var allmodification = ChangeTracker.Entries<Transaction>().Where(entity => entity.State != EntityState.Unchanged);

            foreach (var entity in allmodification)
            {
                Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: { entity.State.ToString()}");
                var type = entity.Entity.GetType();
                var properities = entity.Entity.GetType().GetProperties();
                var properity = properities.Where(pr => pr.Name == "Asset").First();

                var asset = (Asset)properity.GetValue(entity.Entity);
                properity.SetValue(entity.Entity, asset);

                /*ChangeTracker.TrackGraph(entity.Entity, e => {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                });

            }

            var temp = ChangeTracker.Entries().Where(entity => entity.State != EntityState.Unchanged);
            foreach (var entityEntry in temp)
            {
                Console.WriteLine($"Entity: {entityEntry.Entity.GetType().Name},State: { entityEntry.State.ToString()}");

            }*/
            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}