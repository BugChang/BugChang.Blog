using System;
using System.Linq;
using AutoMapper;
using BugChang.Blog.Application.AccountApp.Dto;
using BugChang.Blog.Application.ArchiveApp.Dto;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Application.TagApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.ValueObject;

namespace BugChang.Blog.Application.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Category, CategoryPreviewDto>()
                .ForMember(s => s.PostCount, d => d.MapFrom(src => src.Posts.Count()));

            CreateMap<Category, CategoryNavDto>()
                .ForMember(s => s.PostCount, d => d.MapFrom(src => src.Posts.Count(e=>e.IsPublish)));

            CreateMap<Category, CategoryDto>();

            CreateMap<Post, PostPreviewDto>()
                .ForMember(s => s.Tags, d => d.MapFrom(v => v.Tags.Split(",", StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(s => s.Summary, d => d.MapFrom(v => v.GetSummary(200)));

            CreateMap<Post, PostDetailDto>()
                .ForMember(s => s.Tags, d => d.MapFrom(v => v.Tags.Split(",", StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(s=>s.HtmlContent,d=>d.MapFrom(v=>v.GetHtmlContent()));

            CreateMap<Archive, ArchiveDto>();

            CreateMap<User, UserDto>();

            CreateMap<Comment,CommentDto>();

        }
    }
}
