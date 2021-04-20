using ACMS.DAL.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IPaidSessionRepo : IRepositoryBase<PaidSession>
    {
        public PaidSession FindByConditionWithFKData(Expression<Func<PaidSession, bool>> expression);
        public IQueryable<PaidSession> FindAllByConditionWithFkData(Expression<Func<PaidSession, bool>> expression);
        public IQueryable<PaidSession> FindAllWithFkData();

    }
}