using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(IApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public IEnumerable<Category> GetCategories()
        {
            return DbContext.Categories.Include(category => category.ParentCategory);
        }

        public Category GetCategoryByName(string name)
        {
            Expression<Func<Category, bool>> expression = category => category.Name == name;
            return this.GetAllItems(expression).First();
        }
    }
}