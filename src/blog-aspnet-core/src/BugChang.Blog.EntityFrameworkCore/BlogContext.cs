using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace BugChang.Blog.EntityFrameworkCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "81069681@qq.com",
                UserName = "BugChang",
                Role = Role.Admin,
                DisplayName = "BugChang",
                Password = "cfc094019a8ae07d9e8d4ea7c2c78733",
            });
        }
    }
}
