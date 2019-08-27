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

        //Query returns the total amount of all parent categories for the selected type of operation(Income or Expenses).
        //The result should include only categories that have transactions for selected period.
        //Input parameters in this query will be UserId and OperationType(category type).
        //Each record of the output model should include Category.Name and Amount.
        public List<CategoryInfo> GetCategoriesForPeriod(int userId, string categoryName, DateTime beginDateTime, DateTime endDateTime)
        {
            var categories = _categoryService.GetAllParentCategories(categoryName);
            var transactions = _transactionService.GetUserTransactionsForSelectedPeriod(userId, beginDateTime, endDateTime).GroupBy(transaction => transaction.Category);
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