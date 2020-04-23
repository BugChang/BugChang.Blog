using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.Core;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;

namespace BugChang.Blog.Application.CategoryApp
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryDto GetCategory(int categoryId)
        {
            var category= _categoryRepository.Get(categoryId);
            return _mapper.Map<CategoryDto>(category);
        }

        public IEnumerable<CategoryPreviewDto> GetCategories()
        {
            var categories= _categoryRepository.GetQueryable();
            return _mapper.ProjectTo<CategoryPreviewDto>(categories);
        }

        public void InsertCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.Remove(categoryId);
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Update(category);
        }

        public IEnumerable<string> GetCategoryColors()
        {
            return Category.Colors;
        }
    }
}
