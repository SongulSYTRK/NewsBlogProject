using Microsoft.EntityFrameworkCore.Query;
using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsBlogProject.Infrastructure.Repositories.Interface.IBaseRepository
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

      
        T GetInt(Expression<Func<T, bool>> expression);

        // T GetDefault(Expression<Func<T , bool>> expression);
        TResult GetDefault<TResult>(Expression<Func<T, TResult>> selector,
                                    Expression<Func<T, bool>> expression,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        //  List<T> GetDefaults(Expression<Func<T, bool>> expression);
        List<TResult> GetDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                           Expression<Func<T, bool>> expression,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
