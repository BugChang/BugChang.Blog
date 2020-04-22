using System.Collections.Generic;
using System.Linq;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;

namespace BugChang.Blog.Application.CategoryApp
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryRepository.Get(categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public void InsertCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.Remove(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
