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

        //Query deletes all users' (parameter userId) transactions in the current month (for selected period). 
        public void DeleteUserTransactionsForSelectedPeriod(int userId, DateTime beginDateTime, DateTime endDateTime)
        {
            Expression<Func<Transaction, bool>> expression = transaction =>
                transaction.Asset.User.UserId == userId && beginDateTime <= transaction.Date &&
                endDateTime > transaction.Date;

            _transactionRepository.Delete( _transactionRepository.GetAllItems(expression).ToList());
        }

        //Query returns the transaction list for the selected user(userId) ordered descending by Transaction.Date,
        //then ordered ascending by Asset.Name and
        //then ordered ascending by Category.Name.
        //Each record of the output model includes
        //  Asset.Name,
        //  Category.Name (transaction subcategory),
        //  Category.ParentName (transaction parent category),
        //  Transaction.Amount,
        //  Transaction.Date and Transaction.Comment.
        public List<TransactionInfo> GetUserTransactionsInfo(int userId)
        {
            return _transactionRepository.GetTransactionsWithUserAssetCategoryInfo()
                .Where(transaction => transaction.Asset.User.UserId == userId).
                OrderByDescending(transaction => transaction.Date).ThenBy(transaction => transaction.Asset.Name)
                .ThenBy(transaction => transaction.Category.Name).Select(transaction => new TransactionInfo
                {
                    AssetName = transaction.Asset.Name,
                    CategoryName = transaction.Category.Name,
                    CategoryParentName = (transaction.Category.ParentCategory)?.Name ,
                    TransactionAmount = transaction.Amount,
                    TransactionComment = transaction.Comment,
                    TransactionDate = transaction.Date
                }).ToList();
        }

        //Query returns the total value of income and expenses for the selected period
        //(parameters userId, startDate, endDate) ordered by Transaction.Date and grouped by month.
        //Each record of the output model should include total Income and Expenses, Month and Year.
        public List<Statistics> GetStatisticsForSelectedPeriod(int userId, DateTime beginDateTime, DateTime endDateTime)
        {
            var temp = _transactionRepository.GetTransactionsWithUserAssetCategoryInfo();

            var collection = _transactionRepository.GetTransactionsWithUserAssetCategoryInfo()
                .Where(transaction => transaction.Asset.User.UserId == userId && transaction.Date > beginDateTime && transaction.Date < endDateTime)
                .GroupBy(transaction => (transaction.Date.Month, transaction.Date.Year));

            List<Statistics> list = new List<Statistics>();

            foreach (var groupingTransaction in collection)
            {
                var statisticPerMonth = new Statistics();
                foreach (var transaction in groupingTransaction)
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

                statisticPerMonth.Month = groupingTransaction.Key.Month;
                statisticPerMonth.Year = groupingTransaction.Key.Year;
                list.Add(statisticPerMonth);
            }
            return list;
        }

        public List<Transaction> GetUserTransactionsForSelectedPeriod(int userId, DateTime beginDateTime,
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