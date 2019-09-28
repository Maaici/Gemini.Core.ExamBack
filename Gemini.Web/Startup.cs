using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Gemini.Models;
using Gemini.Redis;
using Gemini.Repositories;
using Gemini.Services;
using Gemini.Web.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Gemini.Web
{
    public class Startup
    {
        public IContainer AutofacContainer;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //设置返回的json结果的字段名首字母大写（默认小写）
                .AddJsonOptions(options=>options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddDbContext<MyDbContext>(options =>
            {
                //options.UseSqlServer(Configuration.GetConnectionString("Test_ExamAffair"));
                //sqlite用于前期开发，后面会迁移到sqlserver
                options.UseSqlite(Configuration.GetConnectionString("Sqlite_Test"));
            });
            services.AddSession();
            services.AddSingleton<ICache>(new RedisOperator(Configuration.GetConnectionString("Redis_Conn")));

            #region 配置AutoMapper

            //注入AutoMapper需要用到的服务，其中包括AutoMapper的配置类 Profile（MappingProfile）
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region 配置Autofac

            ContainerBuilder builder = new ContainerBuilder();
            //将services中的服务填充到Autofac中.
            builder.Populate(services);
            //根据程序集批量注册
            builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
                .Where(t => t.Name.EndsWith("Repository") || t.Name == "UnitOfWork")
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();
            //新模块组件注册
            //builder.RegisterModule<DefaultModuleRegister>();
            //创建容器.
            AutofacContainer = builder.Build();
            //使用容器创建 AutofacServiceProvider 
            return new AutofacServiceProvider(AutofacContainer);

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseStatusCodePages();
            }
            app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default", 
                    template: "{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}
