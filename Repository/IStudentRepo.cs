using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IStudentRepo : IRepositoryBase<Student>
    {
        public Student FindByConditionWithFKData(Expression<Func<Student, bool>> expression);
    }
}