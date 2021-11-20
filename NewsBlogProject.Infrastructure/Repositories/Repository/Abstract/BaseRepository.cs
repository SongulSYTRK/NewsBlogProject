using Microsoft.EntityFrameworkCore;
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

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public void Update(T Entity)
        {
            _db.Entry<T>(Entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
