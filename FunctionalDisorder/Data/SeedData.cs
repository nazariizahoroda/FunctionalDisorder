using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Linq;

namespace FunctionalDisorder.Data
{
    public static class SeedData
    {
        public static void InitializeDatabaseForIdentity(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                if (!dbContext.Roles.Any(r => r.Name == "RegistredUser"))
                {
                    var registredRole = new Role() { Name = "RegistredUser" };
                    roleManager.CreateAsync(registredRole).Wait();
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
