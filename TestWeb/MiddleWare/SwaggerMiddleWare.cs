using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.MiddleWare
{
    /// <summary>
    /// Swagger 中间件
    /// </summary>
    public static class SwaggerMiddleWare
    {
        public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            return serviceCollection.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(Configuration["Swagger:Name"],new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title="MySwagger",
                    Description="Swagger Test",
                    Version= Configuration["Swagger:Version"],
                });
            });
        }
    }
}
