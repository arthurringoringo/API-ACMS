using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IRegistredClassRepo : IRepositoryBase<RegistredClass>
    {
        public RegistredClass FindByConditionWithFKData(Expression<Func<RegistredClass, bool>> expression);
    }
}