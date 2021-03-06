﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Entity.Resource;
using WebApi.Core.Enum.User;

namespace WebApi.Core.Entity.User
{
    public class DbUser : IEntity, IDelete
    {
        public int Id { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        [StringLength(10)]
        public string First_Name { set; get; }

        /// <summary>
        /// 名
        /// </summary>
        [StringLength(10)]
        public string Last_Name { set; get; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public SexEnum Sex { set; get; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { set; get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        public string EmailAdress { set; get; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Phone]
        public string Phone { set; get; }

        public bool IsDeleted { set; get; }

        public DateTime? DeletedTime { set; get; }

        [ForeignKey("DbAccountUser")]
        public int User_AccountUser_Id { set; get; }

        public DbAccountUser DbAccountUser { set; get; }

        public ICollection<DbImageResource> DbImageResources { set; get; }

        //public ICollection<DbMusicResource> DbMusicResources { set; get; }

        //public ICollection<DbVedioResource> DbVedioResources { set; get; }
    }
}
