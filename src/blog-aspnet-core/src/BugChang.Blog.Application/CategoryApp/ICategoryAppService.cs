using System.Collections.Generic;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Application.CategoryApp
{
    public interface ICategoryAppService
    {
        CategoryDto GetCategory(int categoryId);

        IEnumerable<CategoryPreviewDto> GetCategories();

        void InsertCategory(CategoryDto category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(CategoryDto category);

        IEnumerable<string> GetCategoryColors();
    }
}
