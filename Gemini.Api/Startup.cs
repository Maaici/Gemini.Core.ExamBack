using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gemini.Models;
using AutoMapper;
using Gemini.Api.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Gemini.Repositories;
using Gemini.Services;

namespace Gemini.Api
{
    public class Startup
    {
        public IContainer AutofacContainer;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Test_ExamAffair"));
                });


            #region 配置swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API",
                    Description = "api文档",
                    TermsOfService = "None"
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Gemini.Api.xml");
                var xmlPathByModel = Path.Combine(basePath, "Gemini.Api.xml");
                options.IncludeXmlComments(xmlPathByModel);
                //true表示生成控制器描述，包含true的IncludeXmlComments重载应放在最后，或者两句都使用true
                options.IncludeXmlComments(xmlPath, true);
            });

            #endregion

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
            //builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(ValidateService).Assembly)
            //     .Where(t => t.Name.EndsWith("Service"))
            //     .AsImplementedInterfaces();
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
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.ShowExtensions();
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
