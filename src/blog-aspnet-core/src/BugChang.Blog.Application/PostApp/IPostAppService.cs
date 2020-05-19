using System.Collections.Generic;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.PostApp
{
   public interface IPostAppService
    {
        void InsertPost(PostDto postDto);

        IEnumerable<PostPreviewDto> GetPosts();

        PageSearchOutput<PostPreviewDto> GetHomePosts(PageSearchInput pageSearchInput);

        IEnumerable<PostPreviewDto> GetStickyPosts();

        PostDetailDto GetPost(int postId);

        PostDetailDto GetFullContent(int postId);

        void UpdatePost(PostDto postDto);

        void AddComment(CommentDto commentDto);

        PageSearchOutput<CommentDto> GetComments(int postId, PageSearchInput pageSearchInput);
    }
}
