using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface ITeacherRepo : IRepositoryBase<Teacher>
    {
        public Teacher FindByConditionWithFKData(Expression<Func<Teacher, bool>> expression);
    }
}