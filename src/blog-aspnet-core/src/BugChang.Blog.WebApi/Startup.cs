using AutoMapper;
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

namespace BugChang.Blog.WebApi
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

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

            services.AddDbContext<BlogContext>(options => options.UseSqlite("Data Source=../../db/blog.db"));

            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IPostAppService, PostAppService>();

            services.AddScoped<IRepository<Category>, RepositoryBase<Category>>();
            services.AddScoped<IRepository<Post>, RepositoryBase<Post>>();
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
