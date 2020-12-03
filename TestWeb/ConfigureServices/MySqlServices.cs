using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EntityFramework;

namespace WebApi.ConfigureServices
{
    /// <summary>
    /// Mysql  中间件
    /// </summary>
    public static class MySqlServices
    {
        public static IServiceCollection ConfMySqlServices(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            return serviceCollection.AddDbContext<WebApiDbContext>(option =>
            {
                option.UseMySql(Configuration.GetConnectionString("MySql"));
            });
        }
    }
}
