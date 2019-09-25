using System;
using System.Collections.Generic;
using System.Linq;
using MoneyManager.Business.Models;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class CategoryService : BaseService<Category>
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly TransactionService _transactionService;

        public CategoryService(CategoryRepository categoryRepository, TransactionService  transactionService) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _transactionService = transactionService;
        }

        public List<Category> GetAllParentCategories(string categoryName)
        {
            var selectedCategory = _categoryRepository.GetCategoryByName(categoryName);
            if (selectedCategory == null)
                return null;
            var listOfPossibleCategories = new List<Category>();
            while (selectedCategory != null)
            {
                listOfPossibleCategories.Add(selectedCategory);
                selectedCategory = selectedCategory.ParentCategory;
            }
            return listOfPossibleCategories;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        /// <summary>
        /// Query returns the total amount of all parent categories for the selected type of operation(Income or Expenses).
        /// The result should include only categories that have transactions for selected period.
        /// Input parameters in this query will be UserId and OperationType(category type).
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryName"></param>
        /// <param name="beginDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns>Record of the output model includes Category.Name and Amount</returns>
        public List<CategoryInfo> GetCategoriesForPeriod(int userId, string categoryName, DateTime beginDateTime, DateTime endDateTime)
        {
            var categories = GetAllParentCategories(categoryName);
            var transactions = _transactionService.GetUserTransactionsForSelectedPeriod(userId, beginDateTime, endDateTime).GroupBy(transaction => transaction.Category);
            var resultCategories = new List<CategoryInfo>();

            foreach (IGrouping<Category, Transaction> transactionGroup in transactions)
            {
                foreach (Category category in categories)
                {
                    if (transactionGroup.Key == category)
                    {
                        var categoryInfo = new CategoryInfo { CategoryName = category.Name };
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