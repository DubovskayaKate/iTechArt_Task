using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext DbContext;

        public BaseRepository(IApplicationContext dbContext)
        {
            DbContext = dbContext as ApplicationContext;
        }

        public virtual TEntity GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return DbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>()
                .Where(predicate)
                .AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().AddAsync(entity);
            DbContext.SaveChanges();
        }

        public void Insert(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRangeAsync(entities);
            DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Update(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void Delete(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
            DbContext.SaveChanges();
        }

    }
}