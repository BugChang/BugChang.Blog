using System.Collections.Generic;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.TagApp
{
    public interface ITagAppService
    {
        PageSearchOutput<PostPreviewDto> GetPosts(string tagName,PageSearchInput pageSearchInput);

        IEnumerable<string> GetTags();

    }
}
