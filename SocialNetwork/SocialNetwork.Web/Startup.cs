using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.AutoMapperConfigurations;
using SocialNetwork.Services.Services;
using SocialNetwork.Services.Services.Contracts;
using SocialNetwork.Web.AutoMapperConfigurations;
using SocialNetwork.Web.Helpers;
using UserConfig = SocialNetwork.Services.AutoMapperConfigurations.UserConfig;

namespace SocialNetwork.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // // Get "AppSettings" property from the AppSettings.json
            // var appSettingsSection = this.Configuration.GetSection("AppSettings");
            // services.Configure<AppSettings>(appSettingsSection);
            //
            // // Configure jwt authentication
            // var appSettings = appSettingsSection.Get<AppSettings>();
            // var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //
            // services.AddAuthentication(config =>
            // {
            //     config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // })
            //    .AddJwtBearer(config =>
            //    {
            //        config.RequireHttpsMetadata = false;
            //        config.SaveToken = true;
            //        config.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });

            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<SocialNetworkDBContext>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserConfig))); // Review

            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserModelConfig)));



            //  var mapperConfig = new MapperConfiguration(mc =>
            //  {
            //      mc.AddProfile(new UserConfig());
            //      mc.AddProfile(new UserCfg());
            //  });
            //
            //  IMapper mapper = mapperConfig.CreateMapper();
            //  services.AddSingleton(mapper);

            // services.AddMvc();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<ITokenService, TokenService>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/hubs"))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });


            services.AddDbContext<SocialNetworkDBContext>
            (
                 options => options
                           .UseSqlServer(Configuration
                           .GetConnectionString("DefaultConnection"))
            );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
