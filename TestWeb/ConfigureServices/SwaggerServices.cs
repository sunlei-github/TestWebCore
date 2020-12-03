using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace WebApi.ConfigureServices
{
    /// <summary>
    /// Swagger 中间件
    /// </summary>
    public static class SwaggerServices
    {
        public static IServiceCollection ConfSwaggerServices(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            return serviceCollection.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(Configuration["Swagger:Name"],new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title="MySwagger",
                    Description="Swagger Test",
                    Version= Configuration["Swagger:Version"],
                });

                string xmlPath = Path.Combine(AppContext.BaseDirectory, "WebApi.xml");
                option.IncludeXmlComments(xmlPath);
            });
        }
    }
}
