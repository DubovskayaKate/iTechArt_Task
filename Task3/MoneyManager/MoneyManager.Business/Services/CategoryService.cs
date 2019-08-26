using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class CategoryService : BaseService<Category>
    {
        private readonly BaseRepository<Category> _baseRepository;

        public CategoryService(BaseRepository<Category> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

    }
}