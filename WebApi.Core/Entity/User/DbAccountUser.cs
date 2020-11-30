using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Enum.User;

namespace WebApi.Core.Entity.User
{
    /// <summary>
    /// 可以分表    只取登陆账号和密码 失败后才取这张表数据
    /// </summary>
    public class DbAccountUser : IEntity
    {
        public int Id { set; get; }

        [Required]
        [MaxLength(10)]
        [MinLength(5)]
        public string UserName { set; get; }

        /// <summary>
        /// 密码要加密
        /// </summary>
        [Required]
        public string Password { set; get; }

        /// <summary>
        /// 登陆用户的状态
        /// </summary>
        public AccountSatusEnum AccountSatus { set; get; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastAccountTime { set; get; }

        /// <summary>
        /// 登陆失败的次数  超过五次 需要冻结账户  用户申诉 重置密码
        /// </summary>
        public int AccountFailedCount { set; get; }

        [ForeignKey("DbUser")]
        public int AccountUser_User_Id { set; get; }

        public DbUser DbUser { set; get; }
    }
}
