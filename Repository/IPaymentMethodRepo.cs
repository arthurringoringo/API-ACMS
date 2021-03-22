using ACMS.DAL.Models;
using System;
using System.Linq.Expressions;

namespace APIACMS.Repository
{
    public interface IPaymentMethodRepo : IRepositoryBase<PaymentMethod>
    {
        public PaymentMethod FindByConditionWithFKData(Expression<Func<PaymentMethod, bool>> expression);
    }
}