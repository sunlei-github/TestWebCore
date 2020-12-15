using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApi.Core.Enum.User
{
    public enum SexEnum
    {
        /// <summary>
        /// 男人
        /// </summary>
        [Description("男")]
        Man = 1,

        /// <summary>
        /// 女人
        /// </summary>
        [Description("女")]
        Woman = 2
    }
}
