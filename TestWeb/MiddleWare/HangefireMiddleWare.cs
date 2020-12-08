using Hangfire;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.HangfireTask;
using WebApi.IApplication.IServices.IHangefire;

namespace WebApi.MiddleWare
{
    public class HangefireMiddleWare
    {

        /// <summary>
        /// 准备Hangefire 任务
        /// </summary>
        public static void PrepareJob()
        {

            //RecurringJob.AddOrUpdate<IHangefireServices>(Guid.NewGuid().ToString(), p => p.TestJob(), "0/30 * * * * ? ");
        }
    }
}
