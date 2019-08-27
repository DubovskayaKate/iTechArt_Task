using System.Collections.Generic;
using System.Linq;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        private readonly BaseRepository<TEntity> _repository;

        protected BaseService(BaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public List<TEntity> GetAll()
        {
            return _repository.List().ToList();
        }
        public TEntity GetUserById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Insert(TEntity entity)
        {
            _repository.Update(entity);
        }



    }
}