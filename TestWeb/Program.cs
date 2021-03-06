using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //.UseKestrel(c =>
                    //{
                    //    //不限制请求体大小  上传大文件时 可能会报错 this.Request.Form.Files Request body too large.
                    //    c.Limits.MaxRequestBodySize = null;
                    //});
                }).ConfigureLogging((context, builder) =>
                {
                    //可以显示指定log4net的配置文件
                    builder.AddLog4Net();
                })
                //使用ActoFac 容器进行依赖注入
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());

    }
}
