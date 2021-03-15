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

            services.AddScoped<IAvailableClassRepo,AvailableClassRepo>();
            services.AddScoped<IClassCategoryRepo, ClassCategoryRepo>();
            services.AddScoped<IClassReportRepo,ClassReportRepo>();
            services.AddScoped<IPaidSessionRepo, PaidSessionRepo>();
            services.AddScoped<IPaymentMethodRepo, PaymentMethodRepo>();
            services.AddScoped<IRegistredClassRepo, RegistredClassRepo>();
            services.AddScoped<ISessionScheduleRepo, SessionScheduleRepo>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ITeacherRepo, TeacherRepo>();

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
