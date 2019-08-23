using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyManager;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class SelectQueries
    {
        public static List<TEntity> SelectAll<TEntity> (DbSet<TEntity> set) where  TEntity : class
        {
            return set.ToList();
        }

        public static List<User> SelectAllWithIncludes(DbSet<User> set) 
        {
            //return set.Users.Include(item => item.)
            throw new NotImplementedException();
        }
    }
}
