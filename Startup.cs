using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using APIACMS.Infrastructure.DataContext
using ACMS.DAL.DataContext;
using ACMS.DAL.DbExtension;
using System.Reflection;


namespace APIACMS
{
    public class Startup
    {//private const string AllowOrigins = "*";
        readonly string MyPolicyName = "_MyPolicyName";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<APIDbContext>(
                   e =>
                   {
                       e.EnableSensitiveDataLogging();
                       e.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                       sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                           sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                       });

                   });
            services.AddCors(options =>
            {
                options.AddPolicy(MyPolicyName,
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });




            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            app.UpdateDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyPolicyName);
            app.UseHttpsRedirection();
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
