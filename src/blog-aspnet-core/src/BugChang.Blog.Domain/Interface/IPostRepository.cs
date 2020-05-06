using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.ValueObject;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Domain.Interface
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable<Post> GetHomePosts(PageSearchInput pageSearchInput, out int count);


        IEnumerable<Archive> GetArchives();
    }
}
