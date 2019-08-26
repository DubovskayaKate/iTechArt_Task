using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MoneyManager.Business.Models;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    class AssetService : BaseService<Asset>
    {
        private readonly AssetRepository _assetRepository;

        public AssetService(AssetRepository assetRepository) : base(assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public List<AssetWithBalance> GetUserAssetsOrderedByName(int userId)
        {
            Expression<Func<Asset, bool >> expression = asset => asset.User.UserId == userId;
            return _assetRepository.List(expression).Select(asset => new AssetWithBalance
                {Balance = asset.Balance, Name = asset.Name, Id = asset.AssetId}).OrderBy(asset => asset.Name).ToList();
        }

    }
}
