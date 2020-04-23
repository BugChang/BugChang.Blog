using System.Collections.Generic;
using System.Linq;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BugChang.Blog.EntityFrameworkCore.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        public DbSet<T> DbSet { get; set; }

        private readonly BlogContext _blogContext;

        public RepositoryBase(BlogContext blogContext)
        {
            _blogContext = blogContext;
            DbSet = blogContext.Set<T>();
            InitDataBase();

        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IQueryable GetQueryable()
        {
            return DbSet;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = Get(id);
            DbSet.Remove(entity);
            _blogContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
            _blogContext.SaveChanges();
        }

        public void InitDataBase()
        {
            if (_blogContext.Database.EnsureCreated())
            {
                if (!_blogContext.Categories.Any())
                {
                    SeedData();
                }
            }
        }

        public void SeedData()
        {
            for (int i = 0; i < 5; i++)
            {
                var category = new Category
                {
                    Name = $"分类{i + 1}",
                    Color = Category.Colors[i]
                };
                _blogContext.Categories.Add(category);
            }

            _blogContext.SaveChanges();
        }
    }
}
