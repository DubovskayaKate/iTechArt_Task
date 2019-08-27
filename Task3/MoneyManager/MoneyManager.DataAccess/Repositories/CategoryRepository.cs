using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(IApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public List<Category> GetCategories()
        {
            return DbContext.Categories.Include(category => category.ParentCategory).ToList();
        }
    }
}