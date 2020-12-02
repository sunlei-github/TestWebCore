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
        public static IApplicationBuilder UseAuditlog(this IApplicationBuilder builder/*, IRepositoryServices<DbAuditLog> repositoryServices*/)
        {
            return builder.Use(async (context, next) =>
            {
                await next();

                var request = context.Request;
                var response = context.Response;
                DbAuditLog dbAuditLog = new DbAuditLog()
                {
                    ClientAdress = request.Host.Value,
                   ServiceName=request.Path,
                   RequestMethod=request.Method,
                   RequestTime=DateTime.Now
                };

                //await repositoryServices.InsertEntity(dbAuditLog);
            });
        }
    }
}
