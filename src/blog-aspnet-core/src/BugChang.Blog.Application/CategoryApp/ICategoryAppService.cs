using System.Collections.Generic;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Application.CategoryApp
{
    public interface ICategoryAppService
    {
        Category GetCategory(int categoryId);

        IEnumerable<Category> GetCategories();

        void InsertCategory(Category category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(Category category);
    }
}
