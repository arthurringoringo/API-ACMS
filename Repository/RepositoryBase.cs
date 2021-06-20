using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ACMS.DAL.DataContext;
using ACMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace APIACMS.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly APIDbContext _context;
        public RepositoryBase(APIDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }
        public T Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);

                _context.SaveChanges();

                _context.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.ToString());

                
            }
            
        }
        public T Update(T entity)
        {
            
            try
            {

                _context.Set<T>().Update(entity);

                _context.SaveChanges();

                _context.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.ToString());



            }
        }
//softdelete
        public bool Delete(T entity)
        {
              
            try
            {

                _context.Set<T>().Remove(entity);

                _context.SaveChanges();

                _context.Entry(entity).State = EntityState.Detached;

                return true;

            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.ToString());

            }
        }



    }
}
