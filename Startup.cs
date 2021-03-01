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
using ACMS.DAL.DataContext;
using ACMS.DAL.DbExtension;
using APIACMS.Extension;
using System.Reflection;



namespace APIACMS
{
    public class Startup

    {
        private const string AllowOrigins = "*";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepositoryCollection()
                    .AddServiceCollection();
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
                options.AddPolicy(AllowOrigins,
                builder =>
                {
                    builder.WithOrigins(AllowOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen();



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            app.UpdateDatabase();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ACMS API V1");
                
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllowOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
