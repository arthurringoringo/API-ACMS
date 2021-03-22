using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IClassCategoryRepo : IRepositoryBase<ClassCategory>
    {
        public ClassCategory FindByConditionWithFKData(Expression<Func<ClassCategory, bool>> expression);
    }
}