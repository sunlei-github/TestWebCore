using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Entity.SystemLog;
using WebApi.EntityFramework;
using WebApi.Repository.Repository;

namespace WebApi.MiddleWare
{

    /// <summary>
    /// 记录日志的 中间件
    /// </summary>
    public static class AuditlogMiddleWare
    {
        public static IApplicationBuilder UseAuditlog(this IApplicationBuilder builder)
        {
            return builder.Use(async (context, next) =>
            {
                var request = context.Request;
                DbAuditLog dbAuditLog = new DbAuditLog()
                {
                    ClientAdress = request.Host.Value,
                    ServiceName = request.Path,
                    RequestMethod = request.Method,
                    RequestTime = DateTime.Now,
                };
                await next();

                var response = context.Response;
                using (WebApiDbContext dbContext = new WebApiDbContext())
                {
                    await dbContext.DbAuditLogs.AddAsync(dbAuditLog);
                    var dd = await dbContext.SaveChangesAsync();
                }
            });
        }
    }
}
