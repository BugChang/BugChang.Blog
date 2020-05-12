using System.Linq;
using AutoMapper;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Application.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CategoryDto, Category>();

            CreateMap<PostDto, Post>()
                .ForMember(s => s.Tags, d => d.MapFrom(v => string.Join(",", v.Tags)));


        }
    }
}
