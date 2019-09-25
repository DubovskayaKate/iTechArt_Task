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
        /// <summary>
        /// Query returns the asset list for the selected user(userId) ordered by the asset’s name.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Output model includes Asset.Id, Asset.Name and Balance</returns>
        public IEnumerable<AssetWithBalance> GetUserAssetsOrderedByAssetName(int userId)
        {
            
            return _assetRepository.GetAllAssetsByUserIdOrderedByAssetName(userId)
                .Select(asset => 
                    new AssetWithBalance
                    {
                        Balance = asset.Balance,
                        Name = asset.Name,
                        Id = asset.AssetId
                    });
        }

    }
}
