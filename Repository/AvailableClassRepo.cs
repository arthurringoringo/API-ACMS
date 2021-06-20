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
    public class AvailableClassRepo : RepositoryBase<AvailableClass>, IAvailableClassRepo
    {
        private readonly APIDbContext _context;
        public AvailableClassRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public AvailableClass FindByConditionWithFKData(Expression<Func<AvailableClass, bool>> expression)
        {
            return _context.Set<AvailableClass>()
                .Include(d => d.RegistredClasses)
                .Include(d => d.SessionSchedules)
                .Include(d => d.Teacher)
                .ThenInclude(d => d.User).Where(x=> x.Deleted ==false)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public List<AvailableClass> FindAllWithFKData()
        {
            return _context.Set<AvailableClass>()
                .Include(d => d.Teacher)
                .Where(d => d.Deleted == false)
                .AsNoTracking()
                .ToList();
        }

    }
}
