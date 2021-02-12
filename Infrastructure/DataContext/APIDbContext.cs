using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using APIACMS.Infrastructure.Models;

namespace APIACMS.Infrastructure.DataContext
{
    public class APIDbContext : DbContext
    {


        public DbSet<AvailableClass> AvailableClasses { get; set; }
        public DbSet<ClassCategory> ClassCategories { get; set; }
        public DbSet<ClassReport> ClassReports { get; set; }
        public DbSet<PaidSession> PaidSessions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<RegistredClass> RegistredClasses { get; set; }
        public DbSet<SessionSchedule> SessionSchedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { 
        }
        public APIDbContext NewInstance()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<APIDbContext>();
            dbContextOptionsBuilder.UseSqlServer(this.Database.GetDbConnection().ConnectionString);

            return new APIDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
