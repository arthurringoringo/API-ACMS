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
    public class RegistredClassRepo : RepositoryBase<RegistredClass>, IRegistredClassRepo
    {
        private readonly APIDbContext _context;
        public RegistredClassRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public RegistredClass FindByConditionWithFKData(Expression<Func<RegistredClass, bool>> expression)
        {
            return _context.Set<RegistredClass>()
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Class)
                .Include(x => x.PaymentMethod)
                .Include(x => x.Student)
                .Where(expression)
                .FirstOrDefault();
        }
    }
}
