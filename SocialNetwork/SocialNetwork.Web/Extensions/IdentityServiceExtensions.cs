using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Database;
using SocialNetwork.Models;

namespace SocialNetwork.Web.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<SocialNetworkDBContext>();

            return services;
        }
    }
}
