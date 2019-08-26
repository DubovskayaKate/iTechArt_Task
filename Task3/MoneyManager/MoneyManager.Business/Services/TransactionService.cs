using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class TransactionService : BaseService<Transaction>
    {
        private readonly BaseRepository<Transaction> _baseRepository;

        public TransactionService(BaseRepository<Transaction> baseRepository): base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void DeleteUserTransactions(int userId, DateTime beginDateTime, DateTime endDateTime)
        {
            Expression<Func<Transaction, bool>> expression = transaction =>
                transaction.Asset.User.UserId == userId && beginDateTime <= transaction.Date &&
                endDateTime > transaction.Date;

            _baseRepository.Delete( _baseRepository.List(expression).ToList());
        }
    }
}