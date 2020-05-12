using BugChang.Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BugChang.Blog.EntityFrameworkCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
