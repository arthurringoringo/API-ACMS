using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIACMS.Repository;
using APIACMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace APIACMS.Extension
{
    public static class CollectionExtensions
    {
        public static IServiceCollection AddRepositoryCollection(this IServiceCollection services )
        {

            services.AddTransient<IAvailableClassRepo,AvailableClassRepo>();
            services.AddTransient<IClassCategoryRepo, ClassCategoryRepo>();
            services.AddTransient<IClassReportRepo,ClassReportRepo>();
            services.AddTransient<IPaidSessionRepo, PaidSessionRepo>();
            services.AddTransient<IPaymentMethodRepo, PaymentMethodRepo>();
            services.AddTransient<IRegistredClassRepo, RegistredClassRepo>();
            services.AddTransient<ISessionScheduleRepo, SessionScheduleRepo>();
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<ITeacherRepo, TeacherRepo>();

            return services;
        
        }

        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddTransient<IServiceExtension, ServiceExtension>();
            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<IAdminServices, AdminServices>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
