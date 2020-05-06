using System;
using System.Collections.Generic;
using System.Text;
using BugChang.Blog.Application.ArchiveApp.Dto;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Application.ArchiveApp
{
    public interface IArchiveAppService
    {
        IEnumerable<ArchiveDto> GetArchives();

        PageSearchOutput<PostPreviewDto> GetPosts(int year, int month, PageSearchInput pageSearchInput);
    }
}
