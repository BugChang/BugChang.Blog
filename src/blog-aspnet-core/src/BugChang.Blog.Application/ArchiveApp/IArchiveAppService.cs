using System;
using System.Collections.Generic;
using System.Text;
using BugChang.Blog.Application.ArchiveApp.Dto;
using BugChang.Blog.Application.CategoryApp.Dto;

namespace BugChang.Blog.Application.ArchiveApp
{
    public interface IArchiveAppService
    {
        IEnumerable<ArchiveDto> GetArchives();
    }
}
