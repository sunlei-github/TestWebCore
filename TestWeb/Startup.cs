using Autofac;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.MiddleWare;
using System.IO;
using WebApi.Moudle;
using WebApi.Attribute;
using WebApi.ConfigureServices;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hangfire;
using Hangfire.MySql.Core;
using Hangfire.Dashboard;
using WebApi.Application.HangfireTask;
using System.Threading;
using WebApi.IApplication.IServices.IHangefire;

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

            services.ConfMySqlServices(Configuration);
            services.ConfSwaggerServices(Configuration);
            services.ConfHangfireServices(Configuration);

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //�����ϴ��ļ��Ĵ�СΪ���  ����ᱨ��Failed to read the request form. Multipart body length limit 134217728 exceeded
            services.Configure<FormOptions>(option =>
            {
                option.ValueLengthLimit = int.MaxValue;
                option.MultipartBodyLengthLimit = int.MaxValue;
            });
        }

        /// <summary>
        /// ����Autofac�ķ���ע��
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

            #region ʹ��SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint($"/swagger/{Configuration["Swagger:Name"]}/swagger.json", Configuration["Swagger:Version"]);
            });
            #endregion

            #region Hangefire
            app.UseHangfireServer();   //ʹ��hangfire����
            app.UseHangfireDashboard("/hangfire");
     

            #endregion

            app.UseAuditlog();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            HangefireMiddleWare.PrepareJob();
        }
    }
}
