using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMS.DAL.Models;
using ACMS.DAL.DataContext;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace APIACMS.Repository
{
    public class SessionScheduleRepo : RepositoryBase<SessionSchedule>, ISessionScheduleRepo
    {
        private readonly APIDbContext _context;
        public SessionScheduleRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public SessionSchedule FindByConditionWithFKData(Expression<Func<SessionSchedule, bool>> expression)
        {
            return _context.Set<SessionSchedule>()
                .Include(x => x.Class)
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public IQueryable<SessionSchedule> FindAllByConditionWithFKData(Expression<Func<SessionSchedule, bool>> expression)
        {
            return _context.Set<SessionSchedule>()
                .Include(x => x.Class)
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .Where(expression)
                .AsNoTracking();
        }
    }
}
