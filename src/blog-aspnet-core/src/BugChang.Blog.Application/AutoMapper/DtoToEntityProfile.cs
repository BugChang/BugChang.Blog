using System;
using AutoMapper;
using BugChang.Blog.Application.AccountApp.Dto;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.ValueObject;

namespace BugChang.Blog.Application.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CategoryDto, Category>();

            CreateMap<PostDto, Post>()
                .ForMember(s => s.Tags, d => d.MapFrom(v => string.Join(",", v.Tags)));

            CreateMap<CommentDto, Comment>()
                .ForMember(s=>s.CreateTime,d=>d.MapFrom(v=>DateTime.Now));

            CreateMap<RegisterInput, User>()
                .ForMember(s => s.Role, d => d.MapFrom(v => Role.Normal));
        }
    }
}
