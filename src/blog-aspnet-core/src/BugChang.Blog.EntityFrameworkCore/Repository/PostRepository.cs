using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BugChang.Blog.EntityFrameworkCore.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(BlogContext blogContext) : base(blogContext)
        {

        }

        public override void Update(Post entity)
        {
            var post = DbSet.Find(entity.Id);
            post.Title = entity.Title;
            post.CategoryId = entity.CategoryId;
            post.Content = entity.Content;
            post.CoverImgUrl = entity.CoverImgUrl;
            post.IsPublish = entity.IsPublish;
            post.IsSticky = entity.IsSticky;
            post.Tags = entity.Tags;
            BlogContext.SaveChanges();
        }

        public IQueryable<Post> GetHomePosts(int skip, int take, out int count)
        {
            var query = DbSet.Where(p => p.IsPublish);
            count = query.Count();
            return query.OrderByDescending(p => p.Id).Skip(skip).Take(take);
        }

        public override Post Get(int id)
        {
            return DbSet.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
    }
}
