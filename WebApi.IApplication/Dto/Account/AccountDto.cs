using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApi.Core.Enum.User;

namespace WebApi.IApplication.Dto.Account
{
    public class AccountDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(10)]
        [MinLength(5)]
        public string UserName { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { set; get; }
    }

    public class LoginInput : AccountDto
    { }

    /// <summary>
    /// 登陆结果
    /// </summary>
    public class LoginInOutput
    {
        /// <summary>
        /// 登陆用户的状态
        /// </summary>
        public AccountSatusEnum AccountSatus { set; get; }

        /// <summary>
        /// 登陆的错误信息
        /// </summary>
        public string Result { set; get; }

    }

    /// <summary>
    /// 退出登陆输入
    /// </summary>
    public class LoginOutInput
    {
        /// <summary>
        /// 登陆用户的Id
        /// </summary>
        public int UserId { set; get; }
    }

    /// <summary>
    /// 退出登陆结果
    /// </summary>
    public class LoginOutOutput
    {
        /// <summary>
        /// 登出的信息
        /// </summary>
        public string Message { set; get; }
    }
}
