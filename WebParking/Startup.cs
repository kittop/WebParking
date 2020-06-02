using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebParking.Areas.Identity.Data;
using WebParking.Data;

namespace WebParking
{
    public class Startup
    {
        private const string defaultAdminEmail = "admin@web.parking";
        private const string defaultAdminUserName = "admin";
        private const string defaultAdminPassword = "admin123";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<WebParkingUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });



            // Инициализация
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // Автоматическая миграция БД при запуске
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();


                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!roleManager.RoleExistsAsync(Roles.AdminRole).Result)
                {
                    var newRole = roleManager.CreateAsync(new IdentityRole(Roles.AdminRole)).Result;
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<WebParkingUser>>();

                var existingAdmin = userManager.FindByNameAsync(defaultAdminUserName).Result;

                if (existingAdmin == null)
                {
                    var newUser = new WebParkingUser { UserName = defaultAdminUserName, Email = defaultAdminEmail };
                    _ = userManager.CreateAsync(newUser, defaultAdminPassword).Result;
                    _ = userManager.AddToRoleAsync(newUser, "admin").Result;
                }




            }

        }
    }
}