﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class AssetRepository : BaseRepository<Asset>
    {
        public AssetRepository(IApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}