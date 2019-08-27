using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using MoneyManager.Business.Models;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class MixedService
    {
        private readonly CategoryService _categoryService;
        private readonly TransactionService _transactionService;
        public MixedService(CategoryService categoryService, TransactionService transactionService)
        {
            _categoryService = categoryService;
            _transactionService = transactionService;
        }

        //Query returns the total amount of all parent categories for the selected type of operation.
        //The result should include only categories that have transactions during selected period. 
        public List<CategoryInfo> GetCategoriesDuringPeriod(int userId, string categoryName, DateTime beginDateTime, DateTime endDateTime)
        {
            var categories = _categoryService.GetAllParentCategories(categoryName);
            var transactions = _transactionService.GetUserTransactionsDuringSelectedPeriod(userId, beginDateTime, endDateTime).GroupBy(transaction => transaction.Category);
            var resultCategories = new List<CategoryInfo>();

            foreach (IGrouping<Category, Transaction> transactionGroup in transactions)
            {
                foreach (Category category in categories)
                {
                    if (transactionGroup.Key == category)
                    {
                        var categoryInfo = new CategoryInfo{CategoryName = category.Name};
                        foreach (var transaction in transactionGroup)
                        {
                            categoryInfo.Amount += transaction.Amount;
                        }
                        resultCategories.Add(categoryInfo);
                    }
                }
            }

            return resultCategories;

        }
    }
}