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
    public class PaymentMethodRepo : RepositoryBase<PaymentMethod>, IPaymentMethodRepo
    {
        private readonly APIDbContext _context;
        public PaymentMethodRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaymentMethod FindByConditionWithFKData(Expression<Func<PaymentMethod, bool>> expression)
        {
            return _context.Set<PaymentMethod>()
                .Include(x => x.RegistredClasses)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();
        }
    }
}
