using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApplicationTask.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WebApplicationTask.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
      where T : class
    {
        protected DbContextClass _DbContext;

        public RepositoryBase(DbContextClass _dbContext)
        {
            _DbContext = _dbContext;
        }

        public void Delete(T entity)
        {
            _DbContext.Set<T>().Remove(entity);
            _DbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _DbContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _DbContext.Set<T>().Add(entity);
            _DbContext.SaveChanges();
            return entity;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate = null, string include = null)
        {

            IQueryable<T> query;

            if (predicate == null)
            {
                query = _DbContext.Set<T>();
            }
            else
            {
                query = _DbContext.Set<T>().Where(predicate);
            }
            
            if (include != null)
            {
                foreach (var tbl in include.Split(','))
                {
                    query = query.Include(tbl);
                }
            }

            return query;
        }

        public void Update()
        {
            _DbContext.SaveChanges();
        }

        public T UpdateEntity(T entity)
        {
            if (entity != null)
            {
                _DbContext.Entry(entity).State = EntityState.Modified;
                _DbContext.SaveChanges();
            }
            else
            {
                _DbContext.SaveChanges();
            }

            return entity;
        }

    }
}
