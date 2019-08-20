using  Microsoft.EntityFrameworkCore;
using MoneyManagerClassLibrary;

namespace MoneyManager
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}