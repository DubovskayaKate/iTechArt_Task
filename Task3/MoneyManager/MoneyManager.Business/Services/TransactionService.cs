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

        public void DeleteUserTransactionsDuringSelectedPeriod(int userId, DateTime beginDateTime, DateTime endDateTime)
        {
            Expression<Func<Transaction, bool>> expression = transaction =>
                transaction.Asset.User.UserId == userId && beginDateTime <= transaction.Date &&
                endDateTime > transaction.Date;

            _transactionRepository.Delete( _transactionRepository.List(expression).ToList());
        }

        public List<TransactionInfo> GetUserTransactionsInfo(int userId)
        {
            return _transactionRepository.GetTransactionsWithUserAssetCategoryInfo()
                .Where(transaction => transaction.Asset.User.UserId == userId).
                OrderByDescending(transaction => transaction.Date).ThenBy(transaction => transaction.Asset.Name)
                .ThenBy(transaction => transaction.Category.Name).Select(transaction => new TransactionInfo
                {
                    AssetName = transaction.Asset.Name,
                    CategotyName = transaction.Category.Name,
                    CategoryParentName = transaction.Category.ParentCategory != null? transaction.Category.ParentCategory.Name : null,
                    TransactionAmount = transaction.Amount,
                    TransactionComment = transaction.Comment,
                    TransactionDate = transaction.Date
                }).ToList();
        }

        public List<Statistic> GetStatisticsDuringSelectedPeriod(int userId, DateTime beginDateTime, DateTime endDateTime)
        {
            var temp = _transactionRepository.GetTransactionsWithUserAssetCategoryInfo();

            var collection = _transactionRepository.GetTransactionsWithUserAssetCategoryInfo()
                .Where(transaction => transaction.Asset.User.UserId == userId && transaction.Date > beginDateTime && transaction.Date < endDateTime)
                .GroupBy(transaction => ( transaction.Date.Month, transaction.Date.Year));

            List<Statistic> list = new List<Statistic>();

            foreach (var item in collection)
            {
                var statisticPerMonth = new Statistic();
                foreach (var transaction in item)
                {
                    if (transaction.Category.IsExpenses)
                    {
                        statisticPerMonth.Expenses += transaction.Amount;
                    }
                    else
                    {
                        statisticPerMonth.Income += transaction.Amount;
                    }
                }

                statisticPerMonth.Month = item.Key.Item1;
                statisticPerMonth.Year = item.Key.Item2;
                list.Add(statisticPerMonth);
            }
            return list;
        }

        public List<Transaction> GetUserTransactionsDuringSelectedPeriod(int userId, DateTime beginDateTime,
            DateTime endDateTime)
        {
            return _transactionRepository.GetTransactionsWithUserAssetCategoryInfo().Where(transaction =>
                transaction.Asset.User.UserId == userId && transaction.Date > beginDateTime &&
                transaction.Date < endDateTime).ToList();
        }

        public List<Transaction> GetTransactionsWithUserAssetCategoryInfo()
        {
            return _transactionRepository.GetTransactionsWithUserAssetCategoryInfo();
        }
    }
}