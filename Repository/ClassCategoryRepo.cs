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
    public class ClassCategoryRepo : RepositoryBase<ClassCategory>, IClassCategoryRepo
    {
        private readonly APIDbContext _context;
        public ClassCategoryRepo(APIDbContext context)
            :base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ClassCategory FindByConditionWithFKData(Expression<Func<ClassCategory, bool>> expression)
        {
            return _context.Set<ClassCategory>()
                .Include(x => x.RegistredClasses)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();
        }
    }
}
