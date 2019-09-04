using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoneyManager.DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAllItems();
        IEnumerable<T> GetAllItems(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Insert(IEnumerable<T> entity);
        void Delete(IEnumerable<T> entity);
        void Update(IEnumerable<T> entity);
    }
}