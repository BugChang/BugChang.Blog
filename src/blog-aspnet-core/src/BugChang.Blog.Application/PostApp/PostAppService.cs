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
        private readonly IRepository<Comment> _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostAppService(IMapper mapper, IPostRepository postRepository, IUnitOfWork unitOfWork, IRepository<Comment> commentRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _commentRepository = commentRepository;
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

        public IEnumerable<PostPreviewDto> GetStickyPosts()
        {
            var queryable = _postRepository.GetQueryable(p => p.IsPublish && p.IsSticky);
            return _mapper.ProjectTo<PostPreviewDto>(queryable);
        }


        public PostDetailDto GetPost(int postId)
        {
            var post = _postRepository.Get(postId);
            var dto = _mapper.Map<PostDetailDto>(post);
            return dto;
        }

        public PostDetailDto GetFullContent(int postId)
        {
            var post = _postRepository.Get(postId);
            if (post == null || !post.CanRead())
            {
                return null;
            }
            post.ViewCountPlus();
            _unitOfWork.Commit();

            //todo:添加访问记录
            var dto = _mapper.Map<PostDetailDto>(post);
            return dto;
        }

        public void UpdatePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            _postRepository.Update(post);
        }

        public void AddComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            _commentRepository.Add(comment);
            commentDto.Id = comment.Id;

        }

        public PageSearchOutput<CommentDto> GetComments(int postId, PageSearchInput pageSearchInput)
        {
            var pageSearchOutput = new PageSearchOutput<CommentDto>(pageSearchInput);
            var queryable = _commentRepository.GetQueryable(c => c.PostId == postId,c=>c.PostId,false, pageSearchInput, out int count);
            pageSearchOutput.Records = _mapper.ProjectTo<CommentDto>(queryable);
            pageSearchOutput.Total = count;
            return pageSearchOutput;
        }
    }
}
