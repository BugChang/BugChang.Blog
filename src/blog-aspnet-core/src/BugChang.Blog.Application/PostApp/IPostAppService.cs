using System;
using System.Collections.Generic;
using System.Text;
using BugChang.Blog.Application.Core;
using BugChang.Blog.Application.PostApp.Dto;

namespace BugChang.Blog.Application.PostApp
{
   public interface IPostAppService
    {
        void InsertPost(PostDto postDto);

        IEnumerable<PostPreviewDto> GetPosts();

        PageSearchOutput<PostPreviewDto> GetHomePosts(PageSearchInput pageSearchInput);

        PostDetailDto GetPost(int postId);

        void UpdatePost(PostDto postDto);
    }
}
