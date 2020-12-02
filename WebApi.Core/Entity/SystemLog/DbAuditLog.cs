using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;

namespace WebApi.Core.Entity.SystemLog
{
    public class DbAuditLog : IEntity
    {
        public int Id { set; get; }

        /// <summary>
        /// 请求的用户
        /// </summary>
        public string Userid { set; get; }

        /// <summary>
        /// 请求服务名称
        /// </summary>
        public string ServiceName { set; get; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string RequestMethod { set; get; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { set; get; }

        /// <summary>
        /// 返回值
        /// </summary>
        public string ReturnValue { set; get; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime RequestTime { set; get; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string ClientAdress { set; get; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string Expection { set; get; }
    }
}
