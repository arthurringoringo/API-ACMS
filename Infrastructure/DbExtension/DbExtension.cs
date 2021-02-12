using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIACMS.Infrastructure.DataContext;

namespace APIACMS.Infrastructure.DbExtension
{
    public static class DbExtension
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {

                using (var context = serviceScope.ServiceProvider.GetService<APIDbContext>())
                {
                    context.Database.Migrate();
                }


            }


        }
    }
}
