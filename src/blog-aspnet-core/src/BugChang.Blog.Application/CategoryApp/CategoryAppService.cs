using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.Core;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.CategoryApp
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;

        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper, IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public CategoryDto GetCategory(int categoryId)
        {
            var category = _categoryRepository.Get(categoryId);
            return _mapper.Map<CategoryDto>(category);
        }

        public IEnumerable<CategoryPreviewDto> GetCategories()
        {
            var categories = _categoryRepository.GetQueryable();
            return _mapper.ProjectTo<CategoryPreviewDto>(categories);
        }

        public IEnumerable<CategoryNavDto> GetNavList()
        {
            var queryable = _categoryRepository.GetQueryable(c=>c.Posts.Any(p=>p.IsPublish));
            return _mapper.ProjectTo<CategoryNavDto>(queryable);
        }

        public void InsertCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Add(category);
            categoryDto.Id = category.Id;

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

        public PageSearchOutput<PostPreviewDto> GetPosts(int categoryId, PageSearchInput pageSearchInput)
        {
            PageSearchOutput<PostPreviewDto> pageSearchOutput = new PageSearchOutput<PostPreviewDto>(pageSearchInput);
            var queryable = _postRepository.GetQueryable(p => p.CategoryId == categoryId && p.IsPublish, pageSearchInput, out int total);
            pageSearchOutput.Total = total;
            pageSearchOutput.Records = _mapper.ProjectTo<PostPreviewDto>(queryable);
            return pageSearchOutput;
        }
    }
}
