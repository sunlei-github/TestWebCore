using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Enum.User
{
    public enum AccountSatusEnum
    {
        /// <summary>
        /// 正常的账户
        /// </summary>
        Active = 1,

        /// <summary>
        /// 冻结的账户
        /// </summary>
        Freeze = 2,

        /// <summary>
        /// 禁用的账户
        /// </summary>
        Disabled = 3
    }
}
