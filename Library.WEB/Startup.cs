using System.IO;
using AutoMapper;
using Library.BLL.AutoMapperProfiles;
using Library.DAL;
using Library.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.WEB
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<LibraryDb>(/*options =>
                options.UseSqlServer(connection)*/);
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<LibraryDb>();

            services.AddMvc();
            //services.AddAutoMapper();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<BrochureProfile>();
                cfg.AddProfile<MagazineProfile>();
                cfg.AddProfile<PublisherProfile>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "./src/index.html";
                    await next();
                }
            });

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
