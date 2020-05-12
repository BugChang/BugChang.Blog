using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Domain.ValueObject;
using BugChang.Blog.Utility;
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

        public IQueryable<Post> GetHomePosts(PageSearchInput pageSearchInput, out int count)
        {
            var query = DbSet.Where(p => p.IsPublish && !p.IsSticky);
            count = query.Count();
            return query.OrderByDescending(p => p.Id).Skip(pageSearchInput.Skip).Take(pageSearchInput.Take);
        }

        public IEnumerable<Archive> GetArchives()
        {
            var archives = DbSet.Where(p => p.IsPublish).GroupBy(p => new { p.CreateTime.Year, p.CreateTime.Month }).Select(p =>
                   new Archive
                   {
                       Year = p.Key.Year,
                       Month = p.Key.Month,
                       PostCount = p.Count()
                   }).ToList();
            return archives;
        }

        public override Post Get(int id)
        {
            return DbSet.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
    }
}
