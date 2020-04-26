using AutoMapper;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Application.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CategoryDto, Category>();
        }
    }
}
