using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Common.Utitly
{
    public class GuidUtitly
    {
        /// <summary>
        /// 创建Guid
        /// </summary>
        /// <returns></returns>
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
