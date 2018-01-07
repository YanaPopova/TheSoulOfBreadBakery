using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TheSoulOfBreadBakery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminName = "Administrator";

                    var roleExists = await roleManager.RoleExistsAsync(adminName);

                    if (!roleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName
                        });
                    }

                    var adminEmail = "admin@admin.com";
                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new ApplicationUser
                        {
                            Email = adminEmail,
                            UserName = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, "1qaz@Wsx");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                .Wait();
            }
            return app;
        }
    }
}
