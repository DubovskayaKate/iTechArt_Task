using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess
{
    public interface IApplicationContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Asset> Assets { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Category> Categories { get; set; }
        int SaveChanges();

    }
}