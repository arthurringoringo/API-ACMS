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
    public class StudentRepo : RepositoryBase<Student>, IStudentRepo
    {
        private readonly APIDbContext _context;
        public StudentRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Student FindByConditionWithFKData(Expression<Func<Student, bool>> expression)
        {
            return _context.Set<Student>()
                .Include(x => x.RegistredClasses)
                .Include(x => x.SessionSchedules)
                .Include(x => x.User)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();
        }

    }
}
