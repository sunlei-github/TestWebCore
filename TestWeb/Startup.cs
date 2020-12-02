using Autofac;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EntityFramework;
using log4net.Config;
using WebApi.MiddleWare;
using System.IO;
using WebApi.Moudle;
using WebApi.Repository.Repository;
using WebApi.IApplication.IServices.IAccount;
using WebApi.Application.Services;
using WebApi.Attribute;

namespace WebApi
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
            services.AddControllers(mvcOption =>
            {
                mvcOption.Filters.Add<GlobalExpectionFilter>();
            });

            services.AddMySql(Configuration);
            services.AddSwagger(Configuration);


            services.AddScoped(typeof(IRepositoryServices<>), typeof(RepositoryServices<>));
            services.AddScoped<IAccountServices, AccountServices>();

        }

        /// <summary>
        /// 配置Autofac的服务注册
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<AutofacMoudle>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region 使用SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint($"/swagger/{Configuration["Swagger:Name"]}/swagger.json", Configuration["Swagger:Version"]);
            });
            #endregion

            app.UseAuditlog();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
