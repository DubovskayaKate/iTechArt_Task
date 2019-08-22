using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MoneyManager;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Remotion.Linq.Clauses.ResultOperators;

namespace MoneyManagerClassLibrary
{
    public class DataGenerator
    {
        private const string UserPath = "Users.txt";
        private const string AssetPath = "Assets.txt";
        private const string CategoryExpensesPath = "CategoryExpenses.json";
        private const string CategoryIncomePath = "CategoryIncome.json";

        public void GenarateData(ref ApplicationContext context)
        {
            var users = GenerateUsers();
            var assets = GenerateAssets(ref users);
            var categories = GenerateCategories();
            var transactions = GenerateTransactions(ref categories, ref assets);
            context.Users.AddRangeAsync(users);
            context.Assets.AddRangeAsync(assets);
            context.Categories.AddRangeAsync(categories);
            context.Transactions.AddRange(transactions);
        }

        public List<User> GenerateUsers()
        {
            return File.ReadAllLines(UserPath).Select(strUser => strUser.Split(' '))
                .Select(user => new User {Name = user[0], Email = user[1], Balance = 0, Assets = new List<Asset>()})
                .ToList();
        }

        public List<Asset> GenerateAssets(ref List<User> users)
        {
            var random = new Random();
            var strNames = File.ReadAllLines(AssetPath);

            var assets = new List<Asset>();
            foreach (var name in strNames)
            {
                foreach (var user in users)
                {
                    var asset = new Asset
                    {
                        Name = name, User = user, Balance = random.Next(0, 2000), Transactions = new List<Transaction>()
                    };
                    assets.Add(asset);
                    user.Assets.Add(asset);
                    user.Balance += asset.Balance;
                }
            }

            return assets;

        }

        public List<Category> GenerateCategories()
        {
            var expenses = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(CategoryExpensesPath));
            var income = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(CategoryIncomePath));

            return CreateCategories(expenses, true).Union(CreateCategories(income, false)).ToList();
        }

        private List<Category> CreateCategories(Dictionary<string, List<string>> dictionary, bool isExpenses)
        {
            var listCategory = new List<Category>();

            foreach (var categoryTree in dictionary)
            {
                var parent = new Category
                {
                    Name = categoryTree.Key, ParentCategory = null, ChildCategories = new List<Category>(),
                    IsExpenses = isExpenses, TransactionList = new List<Transaction>()
                };
                listCategory.Add(parent);

                foreach (var childName in categoryTree.Value)
                {
                    var childCategory = new Category
                    {
                        Name = childName,
                        ParentCategory = parent,
                        ChildCategories = null,
                        IsExpenses = isExpenses,
                        TransactionList = new List<Transaction>()
                    };
                    listCategory.Add(childCategory);
                    parent.ChildCategories.Add(childCategory);
                }
            }
            return listCategory;
        }

        public List<Transaction> GenerateTransactions(ref List<Category> categories, ref List<Asset> assets)
        {
            var transactionList = new List<Transaction>();
            var random = new Random();

            foreach (var category in categories)
            {
                foreach (var asset in assets)
                {
                    var transaction = new Transaction
                    {
                        Asset = asset, Category = category, Amount = random.Next(0, 4000), Comment = "Info",
                        Date = new DateTime(random.Next(1990, 2018), random.Next(1, 12), random.Next(1, 28),
                            random.Next(0, 23), random.Next(0, 60), random.Next(0, 60))
                    };
                    category.TransactionList.Add(transaction);
                    asset.Transactions.Add(transaction);
                    transactionList.Add(transaction);
                }
            }

            return transactionList;
        }
    }
}
