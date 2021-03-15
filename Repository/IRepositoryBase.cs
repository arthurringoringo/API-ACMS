using System;
using System.Linq;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll();
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}