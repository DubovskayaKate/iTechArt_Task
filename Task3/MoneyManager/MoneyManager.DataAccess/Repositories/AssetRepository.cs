using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class AssetRepository : BaseRepository<Asset>
    {
        public AssetRepository(IApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public IEnumerable<Asset> GetAllAssetsByUserIdOrderedByAssetName(int userId)
        {
            Expression<Func<Asset, bool>> expression = asset => asset.User.UserId == userId;
            return this.GetAllItems(expression).OrderBy(asset => asset.Name);
        }
    }
}