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
    public class PaidSessionRepo : RepositoryBase<PaidSession>, IPaidSessionRepo
    {
        private readonly APIDbContext _context;
        public PaidSessionRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaidSession FindByConditionWithFKData(Expression<Func<PaidSession, bool>> expression)
        {
            return _context.Set<PaidSession>()
                .AsNoTracking()
                .Include(x => x.Student)
                .Include(x => x.Class)
                .Where(expression)
                .FirstOrDefault();
        }
    }
}
