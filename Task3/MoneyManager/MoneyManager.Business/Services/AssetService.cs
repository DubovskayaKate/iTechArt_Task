using System;
using System.Collections.Generic;
using System.Text;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    class AssetService : BaseService<Asset>
    {
        private readonly BaseRepository<Asset> _baseRepository;

        public AssetService(BaseRepository<Asset> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
