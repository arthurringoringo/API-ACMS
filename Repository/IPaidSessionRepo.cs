using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IPaidSessionRepo : IRepositoryBase<PaidSession>
    {
        public PaidSession FindByConditionWithFKData(Expression<Func<PaidSession, bool>> expression);
    }
}