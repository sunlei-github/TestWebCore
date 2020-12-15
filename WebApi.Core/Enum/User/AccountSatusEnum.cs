using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApi.Core.Enum.User
{
    public enum AccountSatusEnum
    {
        /// <summary>
        /// 正常的账户
        /// </summary>
        [Description("正常")]
        Active = 1,

        /// <summary>
        /// 冻结的账户
        /// </summary>
        [Description("冻结")]
        Freeze = 2,

        /// <summary>
        /// 禁用的账户
        /// </summary>
        [Description("禁用")]
        Disabled = 3
    }
}
