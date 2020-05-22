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

        public BlogContext BlogContext { get; set; }

        public RepositoryBase(BlogContext blogContext)
        {
            BlogContext = blogContext;
            DbSet = blogContext.Set<T>();


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
            return GetQueryable(whereExpression, a => a.Id, true, pageSearchInput, out total);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> whereExpression, Expression<Func<T, int>> orderExpression, bool desc, PageSearchInput pageSearchInput, out int total)
        {
            var queryable = DbSet.Where(whereExpression);
            total = queryable.Count();

            queryable = !desc ? queryable.OrderBy(orderExpression) : queryable.OrderByDescending(orderExpression);

            return queryable.Skip(pageSearchInput.Skip).Take(pageSearchInput.Take);
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



    }
}
