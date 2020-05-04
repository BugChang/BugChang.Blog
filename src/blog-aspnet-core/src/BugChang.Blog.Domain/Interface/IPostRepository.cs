using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Domain.Interface
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable<Post> GetHomePosts(int skip, int take, out int count);
    }
}
