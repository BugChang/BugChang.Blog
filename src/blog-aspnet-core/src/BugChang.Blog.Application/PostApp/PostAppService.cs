using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BugChang.Blog.Application.Core;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.PostApp
{
    public class PostAppService : IPostAppService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostAppService(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public void InsertPost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.CreateTime = DateTime.Now;
            _postRepository.Add(post);
            postDto.Id = post.Id;
        }

        public IEnumerable<PostPreviewDto> GetPosts()
        {
            return _mapper.ProjectTo<PostPreviewDto>(_postRepository.GetQueryable());

        }

        public PageSearchOutput<PostPreviewDto> GetHomePosts(PageSearchInput pageSearchInput)
        {
            var pageSearchOutput = new PageSearchOutput<PostPreviewDto>(pageSearchInput);
            var queryable = _postRepository.GetHomePosts(pageSearchInput, out int count);
            pageSearchOutput.Records = _mapper.ProjectTo<PostPreviewDto>(queryable);
            pageSearchOutput.Total = count;
            return pageSearchOutput;
        }


        public PostDetailDto GetPost(int postId)
        {
            var post = _postRepository.Get(postId);
            var dto = _mapper.Map<PostDetailDto>(post);
            return dto;
        }

        public void UpdatePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            _postRepository.Update(post);
        }
    }
}
