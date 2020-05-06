using System.Collections.Generic;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.CategoryApp
{
    public interface ICategoryAppService
    {
        CategoryDto GetCategory(int categoryId);

        IEnumerable<CategoryPreviewDto> GetCategories();

        IEnumerable<CategoryNavDto> GetNavList();

        void InsertCategory(CategoryDto category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(CategoryDto category);

        IEnumerable<string> GetCategoryColors();

        PageSearchOutput<PostPreviewDto> GetPosts(int categoryId,PageSearchInput pageSearchInput);
    }
}
