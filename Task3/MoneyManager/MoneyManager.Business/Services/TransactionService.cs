using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Business.Models;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class TransactionService : BaseService<Transaction>
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository): base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void DeleteUserTransactions(int userId, DateTime beginDateTime, DateTime endDateTime)
        {
            Expression<Func<Transaction, bool>> expression = transaction =>
                transaction.Asset.User.UserId == userId && beginDateTime <= transaction.Date &&
                endDateTime > transaction.Date;

            _transactionRepository.Delete( _transactionRepository.List(expression).ToList());
        }

        public List<TransactionInfo> GetUserTransactionsInfo(int userId)
        {
            return _transactionRepository.GetTransactionsWithUserAssetCategoryInfo()
                .OrderByDescending(transaction => transaction.Date).ThenBy(transaction => transaction.Asset.Name)
                .ThenBy(transaction => transaction.Category.Name).Select(transaction => new TransactionInfo
                {
                    AssetName = transaction.Asset.Name,
                    CategotyName = transaction.Category.Name,
                    CategoryParentName = transaction.Category.ParentCategory.Name,
                    TransactionAmount = transaction.Amount,
                    TransactionComment = transaction.Comment,
                    TransactionDate = transaction.Date
                }).ToList();
        }

    }
}