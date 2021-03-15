using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IAvailableClassRepo : IRepositoryBase<AvailableClass>
    {
        public AvailableClass FindByConditionWithFKData(Expression<Func<AvailableClass, bool>> expression);
    }
}