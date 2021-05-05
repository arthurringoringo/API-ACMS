using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIACMS.Extension
{
    public static class ImageFileExtension
    {

        public static void CreateImageDirectory(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
              
                System.IO.Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", "BankReciept"));

            }


        }
    }
}
