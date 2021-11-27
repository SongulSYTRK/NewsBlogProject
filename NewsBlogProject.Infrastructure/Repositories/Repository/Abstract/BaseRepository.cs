using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NewsBlogProject.Infrastructure.Context;
using NewsBlogProject.Infrastructure.Repositories.Interface.IBaseRepository;
using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsBlogProject.Infrastructure.Repositories.Repository.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;
        protected DbSet<T> _table;
        public BaseRepository(AppDbContext appDbContext)
        {
            this._db = appDbContext;
            this._table = _db.Set<T>();
        }
        public void Create(T Entity)
        {
            _db.Add(Entity);
            _db.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _db.Entry<T>(Entity).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public T GetInt(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public List<TResult> GetDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                 Expression<Func<T, bool>> expression,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            IQueryable<T> query = _table;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderby != null)
            {
                return orderby(query).Select(selector).ToList();
            }
            else
            {
                return query.Select(selector).ToList();

            }
        }

        public TResult GetDefault<TResult>(Expression<Func<T, TResult>> selector, 
                                           Expression<Func<T, bool>> expression,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            // return _table.Where(expression).Select(selector).FirstOrDefault();
            IQueryable<T> query = _table;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return query.Select(selector).FirstOrDefault();
        }

        public void Update(T Entity)
        {
            _db.Entry<T>(Entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
