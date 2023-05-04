using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApplicationTask.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate = null, string Include = null);
        T GetById(int id);
        T Insert(T entity);
        void Delete(T entity);
        void Update();
        T UpdateEntity(T entity);
    }
}
