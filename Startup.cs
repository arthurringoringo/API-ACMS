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
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json.Serialization;

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
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
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
                       e.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                       e.EnableSensitiveDataLogging();

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
            services.AddControllers().AddNewtonsoftJson(x => {
                x.SerializerSettings.ContractResolver = new DefaultContractResolver();
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
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
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Resources")),
                RequestPath = new PathString("/Resources")
            });
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
