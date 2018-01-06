using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TheSoulOfBreadBakery.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TheSoulOfBreadBakery.Services;

namespace TheSoulOfBreadBakery
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            //services.AddTransient<IBreadRepository, MockBreadRepository>();

            //register repositories with the dependency injection container
            services.AddTransient<IBreadRepository, BreadRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteBread", policy => policy.RequireClaim("Delete Bread", "Delete Bread"));
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Bread/{action}/{category?}",
                    defaults: new { Controller = "Bread", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //DbInitializer.Seed(app);
        }
    }
}
