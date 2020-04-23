using System.Collections.Generic;
using System.Linq;
using BugChang.Blog.Domain.Entity;

namespace BugChang.Blog.Domain.Interface
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        IQueryable GetQueryable();

        void Add(T entity);

        void Remove(int id);

        void Update(T entity);
    }
}
