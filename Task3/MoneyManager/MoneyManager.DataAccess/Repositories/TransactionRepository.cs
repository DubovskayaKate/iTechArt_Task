using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(IApplicationContext applicationContext): base(applicationContext)
        {
            
        }


        public List<Transaction> GetTransactionsWithUserAssetCategoryInfo()
        {
            return DbContext.Transactions
                .Include(transaction => transaction.Category)
                    .ThenInclude(category => category.ParentCategory)
                .Include(transaction => transaction.Asset)
                    .ThenInclude(asset => asset.User).ToList();

        }

        public List<Transaction> GetTransactionsWithCategoryInfo()
        {
            return DbContext.Transactions.Include(transaction => transaction.Category).ToList();
        }
    }
}