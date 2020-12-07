using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Hangfire;
using Hangfire.MySql.Core;

namespace WebApi.ConfigureServices
{
    /// <summary>
    /// Hangfire 配置
    /// </summary>
    public static class HangefireServices
    {
        public static IServiceCollection ConfHangfireServices(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {

            return serviceCollection.AddHangfire(conf => conf.UseStorage(new MySqlStorage(Configuration.GetConnectionString("MySql"), new MySqlStorageOptions
            {
                TransactionIsolationLevel = System.Data.IsolationLevel.ReadCommitted,   //事务隔离级别  默认是读取以提交
                QueuePollInterval = TimeSpan.FromSeconds(15),  //作业队列轮询间隔 默认是15s
                JobExpirationCheckInterval = TimeSpan.FromHours(1),  // 作业到期检查间隔 
                CountersAggregateInterval = TimeSpan.FromMinutes(5), // 聚合计数器的间隔，默认是5分钟
                PrepareSchemaIfNecessary = true, //设置为true 创建数据库表
                DashboardJobListLimit = 50000, //仪表板作业列表限制 默认值是50000
                TransactionTimeout = TimeSpan.FromMinutes(1),  //事务超时时间 默认是1分钟
                TablePrefix = "Hangfire"  //数据库表的前缀默认是 none
            })));
        }
    }
}
