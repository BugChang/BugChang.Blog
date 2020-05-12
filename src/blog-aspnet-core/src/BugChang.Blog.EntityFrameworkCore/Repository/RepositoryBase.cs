using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Utility;
using Microsoft.EntityFrameworkCore;

namespace BugChang.Blog.EntityFrameworkCore.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        public DbSet<T> DbSet { get; set; }

        public  BlogContext BlogContext { get; set; }

        public RepositoryBase(BlogContext blogContext)
        {
            BlogContext = blogContext;
            DbSet = blogContext.Set<T>();
            InitDataBase();

        }

        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return DbSet;
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> whereExpression)
        {
            return DbSet.Where(whereExpression);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> whereExpression, PageSearchInput pageSearchInput, out int total)
        {
            var queryable = DbSet.Where(whereExpression);
            total = queryable.Count();
            return queryable.OrderByDescending(e => e.Id).Skip(pageSearchInput.Skip).Take(pageSearchInput.Take);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            BlogContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = Get(id);
            DbSet.Remove(entity);
            BlogContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
            BlogContext.SaveChanges();
        }

        public void InitDataBase()
        {
            if (BlogContext.Database.EnsureCreated())
            {
                if (!BlogContext.Categories.Any())
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
                BlogContext.Categories.Add(category);
            }

            var user = new User
            {
                Email = "81069681@qq.com",
                UserName = "BugChang",
                DisplayName = "BugChang",
                Password = "cfc094019a8ae07d9e8d4ea7c2c78733",
            };

            BlogContext.Users.Add(user);
            BlogContext.SaveChanges();
        }
    }
}
