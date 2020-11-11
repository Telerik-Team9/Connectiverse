using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetwork.Services.AutoMapperConfigurations;
using SocialNetwork.Web.Extensions;
using System.Reflection;

namespace SocialNetwork.Web
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
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddApplicationServices(this.configuration);
            services.AddIdentityServices(this.configuration);

            //services.AddAutoMapper(Assembly.GetAssembly(typeof(UserModelConfig)));
            //services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IPostService, PostService>();
            //services.AddScoped<ICommentService, CommentService>();
            //services.AddScoped<ILikeService, LikeService>();
            //services.AddScoped<ITownService, TownService>();
            //services.AddScoped<ITokenService, TokenService>();
            //services.AddDbContext<SocialNetworkDBContext>
            //(
            //     options => options
            //               .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            //);
            //services.AddDefaultIdentity<User>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredUniqueChars = 0;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //})
            //    .AddRoles<Role>()
            //    .AddEntityFrameworkStores<SocialNetworkDBContext>();
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
