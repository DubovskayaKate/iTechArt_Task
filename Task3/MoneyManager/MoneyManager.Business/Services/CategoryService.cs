using System;
using System.Collections.Generic;
using System.Linq;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class CategoryService : BaseService<Category>
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAllParentCategories(string categoryName)
        {
            var selectedCategory = _categoryRepository.GetCategoies().Where(category => category.Name == categoryName ).First();
            if (selectedCategory == null)
                return null;
            var listOfPossibleCategories = new List<Category>();
            while (selectedCategory != null)
            {
                listOfPossibleCategories.Add(selectedCategory);
                selectedCategory = selectedCategory.ParentCategory;
            }
            return listOfPossibleCategories;
        }

    }
}