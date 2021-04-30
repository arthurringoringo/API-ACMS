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
    public class TeacherRepo : RepositoryBase<Teacher>, ITeacherRepo
    {
        private readonly APIDbContext _context;
        public TeacherRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Teacher FindByConditionWithFKData(Expression<Func<Teacher, bool>> expression)
        {
            return _context.Set<Teacher>()
                .Include(x => x.AvailableClasses)
                .Include(x => x.SessionSchedules)
                .Include(x => x.User)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();
        }
    }
}
