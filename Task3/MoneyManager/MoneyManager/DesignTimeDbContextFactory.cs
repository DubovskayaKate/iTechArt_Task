using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace MoneyManager
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = "Server=WSC-160-71\\SQLEXPRESS;Database=MoneyManager;Trusted_Connection=True;";
            builder.UseSqlite(connectionString);
            return new ApplicationContext(builder.Options);
        }
    }
}
