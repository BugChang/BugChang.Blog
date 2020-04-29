using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;

namespace BugChang.Blog.Application.PostApp
{
    public class PostAppService : IPostAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Post> _postRepository;

        public PostAppService(IMapper mapper, IRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public void InsertPost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            _postRepository.Add(post);
            post.Id = post.Id;
        }
    }
}
