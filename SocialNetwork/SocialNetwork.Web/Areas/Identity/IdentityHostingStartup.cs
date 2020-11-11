using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SocialNetwork.Web.Areas.Identity.IdentityHostingStartup))]
namespace SocialNetwork.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}