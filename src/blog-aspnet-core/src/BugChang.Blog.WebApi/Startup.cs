using AutoMapper;
using BugChang.Blog.Application.ArchiveApp;
using BugChang.Blog.Application.AutoMapper;
using BugChang.Blog.Application.CategoryApp;
using BugChang.Blog.Application.Core;
using BugChang.Blog.Application.PostApp;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.EntityFrameworkCore;
using BugChang.Blog.EntityFrameworkCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BugChang.Blog.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

            services.AddDbContext<BlogContext>(options => options.UseLoggerFactory(MyLoggerFactory).UseSqlite("Data Source=../../db/blog.db"));

            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IPostAppService, PostAppService>();
            services.AddScoped<IArchiveAppService, ArchiveAppService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
