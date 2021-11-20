using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NewsBlogProject.Infrastructure.Repositories.Interface.IBaseRepository
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

        T GetDefault(Expression<Func<T , bool>> expression);
        List<T> GetDefaults(Expression<Func<T, bool>> expression);
    }
}
