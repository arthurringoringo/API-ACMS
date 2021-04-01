using ACMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IRegistredClassRepo : IRepositoryBase<RegistredClass>
    {
       
        public RegistredClass FindByConditionWithFKData(Expression<Func<RegistredClass, bool>> expression);
        public IQueryable<RegistredClass> FindAllByConditionWithFKData(Expression<Func<RegistredClass, bool>> expression);
    }
}