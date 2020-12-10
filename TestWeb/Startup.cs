using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;
using WebApi.MiddleWare;
using WebApi.Moudle;
using WebApi.Attribute;
using WebApi.ConfigureServices;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


            //string dd = Configuration.GetSection("Jwt:Secret").Value;
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            //{
            //    option.SaveToken = true;

            //    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidIssuer = Configuration.GetSection("Jwt:Issure").Value,
            //        ValidAudience = Configuration.GetSection("Jwt:Audience").Value,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt:Secret").Value)),
            //        ValidateIssuerSigningKey = true
            //    };
            //});


            //设置上传文件的大小为最大  否则会报错Failed to read the request form. Multipart body length limit 134217728 exceeded
            services.Configure<FormOptions>(option =>
            {
                option.ValueLengthLimit = int.MaxValue;
                option.MultipartBodyLengthLimit = int.MaxValue;
            });
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

            #region Hangefire
            app.UseHangfireServer();   //使用hangfire服务
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
