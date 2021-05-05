using ACMS.DAL.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface ISessionScheduleRepo : IRepositoryBase<SessionSchedule>
    {
        public SessionSchedule FindByConditionWithFKData(Expression<Func<SessionSchedule, bool>> expression);
        public IQueryable<SessionSchedule> FindAllByConditionWithFKData(Expression<Func<SessionSchedule, bool>> expression);
    }
}