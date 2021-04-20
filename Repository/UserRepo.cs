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
    public class UserRepo : RepositoryBase<Student>, IUserRepo
    {
        private readonly APIDbContext _context;
        public UserRepo(APIDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


    }
}
