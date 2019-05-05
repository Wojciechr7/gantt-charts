using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace my_gantt.Models
{
    public static class GanttInitializerExtension
    {
        public static IWebHost InitializeDatabase(this IWebHost webHost)
        {
            var serviceScopeFactory =
                (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<GanttContext>();
                dbContext.Database.EnsureCreated();
                GanttSeeder.Seed(dbContext);
            }

            return webHost;
        }
    }
}
