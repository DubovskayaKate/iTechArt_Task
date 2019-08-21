using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MoneyManager;
using System.IO;
using System.Linq;
using Remotion.Linq.Clauses.ResultOperators;

namespace MoneyManagerClassLibrary
{
    public class DataGenerator
    {
        private ApplicationContext applicationContext { get; }
        private readonly string userPath = "Users.txt";
        private readonly string assetPath = "Assets.txt";

        public DataGenerator(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void FillDatabase()
        {
            throw new NotImplementedException();
        }

        public List<User> GenerateUsers()
        {

            return File.ReadAllLines(userPath).Select(strUser => strUser.Split(' '))
                .Select(user => new User {Name = user[0], Email = user[1], Balance = 0, Assets = new List<Asset>()})
                .ToList();

        }

        public List<Asset> GenerateAssets(ref List<User> users)
        {
            var random = new Random();
            /*return File.ReadAllLines(assetPath).Join(users, name => name, user => user,
            (name, user) => new Asset {Name = name, Balance = random.Next(0, 2000), User = user});*/
            var strNames = File.ReadAllLines(assetPath);

            var assets = new List<Asset>();
            foreach (var name in strNames)
            {
                foreach (var user in users)
                {
                    var asset = new Asset {Name = name, User = user, Balance = random.Next(0, 2000)};
                    assets.Add(asset);
                    user.Assets.Add(asset);
                }
            }

            return assets;

        }

        public void GenerateCategories()
        {
            throw new NotImplementedException();
        }

        public void GenerateTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
