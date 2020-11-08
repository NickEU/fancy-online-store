using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Remove(T entity);
    }
}
