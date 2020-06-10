using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using BugChang.Blog.Application.AccountApp;
using BugChang.Blog.Application.ArchiveApp;
using BugChang.Blog.Application.AutoMapper;
using BugChang.Blog.Application.CategoryApp;
using BugChang.Blog.Application.PostApp;
using BugChang.Blog.Application.TagApp;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Domain.Service;
using BugChang.Blog.EntityFrameworkCore;
using BugChang.Blog.EntityFrameworkCore.Repository;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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
            = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddMemoryCache();

            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,

                        ValidIssuer = Configuration.GetSection("JwtSetting:Issuer").Value,
                        ValidAudience = Configuration.GetSection("JwtSetting:Audience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSetting:SecurityKey").Value)),

                        /***********************************TokenValidationParameters�Ĳ���Ĭ��ֵ***********************************/
                        RequireSignedTokens = true,
                        SaveSigninToken = false,
                        ValidateActor = false,
                        // ������������������Ϊfalse�����Բ���֤Issuer��Audience�����ǲ�������������
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = false,
                        // �Ƿ�Ҫ��Token��Claims�б������Expires
                        RequireExpirationTime = true,
                        // ����ķ�����ʱ��ƫ����
                        //ClockSkew = TimeSpan.FromSeconds(60),
                        // �Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
                        ValidateLifetime = true
                    };
                });


            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BlogContext>(options => options.UseLoggerFactory(MyLoggerFactory).UseMySql(connectionString));

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IPostAppService, PostAppService>();
            services.AddScoped<IArchiveAppService, ArchiveAppService>();
            services.AddScoped<ITagAppService, TagAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();

            services.AddScoped<UserService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRepository<User>, RepositoryBase<User>>();
            services.AddScoped<IRepository<Comment>, RepositoryBase<Comment>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(env.IsDevelopment() ? "/error-local-development" : "/error");

            app.UseStaticFiles();

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
