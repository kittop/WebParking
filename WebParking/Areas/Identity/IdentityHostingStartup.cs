using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebParking.Areas.Identity.Data;
using WebParking.Data;

[assembly: HostingStartup(typeof(WebParking.Areas.Identity.IdentityHostingStartup))]
namespace WebParking.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebParkingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebParkingContextConnection")));

                services.AddDefaultIdentity<WebParkingUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebParkingContext>();
            });
        }
    }
}