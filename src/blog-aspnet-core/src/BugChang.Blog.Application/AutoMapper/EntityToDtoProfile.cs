using System;
using System.Linq;
using AutoMapper;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Application.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Category, CategoryPreviewDto>()
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.Posts.Count()));

            CreateMap<Category, CategoryDto>();

            CreateMap<Post, PostPreviewDto>()
                .ForMember(s => s.Tags, d => d.MapFrom(v => v.Tags.Split(",", StringSplitOptions.None)));
        }
    }
}
