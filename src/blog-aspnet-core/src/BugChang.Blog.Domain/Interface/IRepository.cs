using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Domain.Interface
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        IQueryable<T> GetQueryable();

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> whereExpression);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> whereExpression,PageSearchInput pageSearchInput,out int total);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> whereExpression, Expression<Func<T, int>> orderExpression,
            bool desc, PageSearchInput pageSearchInput, out int total);

        void Add(T entity);

        void Remove(int id);

        void Update(T entity);
    }
}
