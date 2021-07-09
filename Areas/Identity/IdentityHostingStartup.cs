using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrApplianceRepair.Areas.Identity.Data;
using OrApplianceRepair.Data;

[assembly: HostingStartup(typeof(OrApplianceRepair.Areas.Identity.IdentityHostingStartup))]
namespace OrApplianceRepair.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OrApplianceRepairContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OrApplianceRepairContextConnection")));

                services.AddDefaultIdentity<OrApplianceRepairUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<OrApplianceRepairContext>();
            });
        }
    }
}