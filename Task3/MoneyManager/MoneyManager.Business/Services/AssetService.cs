using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        //Query returns the asset list for the selected user(userId) ordered by the asset’s name.
        //Each record of the output model includes Asset.Id, Asset.Name and Balance
        public List<AssetWithBalance> GetUserAssetsOrderedByAssetName(int userId)
        {
            Expression<Func<Asset, bool >> expression = asset => asset.User.UserId == userId;
            return _assetRepository.GetAllItems(expression)
                .Select(asset => 
                    new AssetWithBalance
                    {
                        Balance = asset.Balance,
                        Name = asset.Name,
                        Id = asset.AssetId
                    })
                .OrderBy(asset => asset.Name)
                .ToList();
        }

    }
}
