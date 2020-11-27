using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.AutoMapperConfigs;
using SocialNetwork.Web.Hubs;
using System.Reflection;

namespace SocialNetwork.Web.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //services.AddAutoMapper(typeof(Profile).Assembly);
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserVMConfig)));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAzureBlobService, AzureBlobService>();
            services.AddScoped<IChatService, ChatService>();

            services.AddSignalR();

            services.AddDbContext<SocialNetworkDBContext>
            (
                 options => options
                           .UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}
