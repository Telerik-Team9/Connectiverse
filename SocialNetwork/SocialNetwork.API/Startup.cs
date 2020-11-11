using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetwork.API.Extensions;
using SocialNetwork.Web.AutoMapperConfigurations;
using System.Reflection;
using UserConfig = SocialNetwork.Services.AutoMapperConfigurations.UserConfig;

namespace SocialNetwork.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserConfig))); // Review
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserModelConfig)));

            services.AddApplicationServices(this.configuration);
            services.AddIdentityServices(this.configuration);
            services.AddSwaggerServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(policies => policies.AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .WithOrigins("http://localhost:4200"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/SocialNetworkAPI/swagger.json",
                    "Social Network API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
