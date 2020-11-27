using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EntityFramework;

namespace WebApi.MiddleWare
{
    /// <summary>
    /// Mysql  中间件
    /// </summary>
    public static class MySqlMiddleWare
    {
        public static IServiceCollection AddMySql(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            return serviceCollection.AddDbContext<WebApiDbContext>(option =>
            {
                option.UseMySql(Configuration.GetConnectionString("MySql"));
            });
        }
    }
}
