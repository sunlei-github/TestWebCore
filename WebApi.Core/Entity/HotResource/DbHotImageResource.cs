using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Entity.Resource;
using WebApi.Core.Entity.User;

namespace WebApi.Core.Entity.HotResource
{
    /// <summary>
    /// 图片的 三连表
    /// </summary>
    public class DbHotImageResource : IHotResource
    {
        public int Id { set; get; }

        /// <summary>
        /// 是否投币
        /// </summary>
        public bool PayCoin { set; get; }

        /// <summary>
        /// 是否点赞
        /// </summary>
        public bool ClickLike { set; get; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool Collect { set; get; }

        public ICollection<DbHotImageResourceUser> DbHotImageReSourceUsers { set; get; }

        /// <summary>
        /// 三连的用户
        /// </summary>
        public DbUser TrigeminyUser { set; get; }

        public int CreatorUserId { set; get; }

        public DateTime? CreateTime { set; get; }

        public int? LastModifierUserId { set; get; }

        public DateTime LastModifionTime { set; get; }

        public bool IsDeleted { set; get; }

        public DateTime? DeletedTime { set; get; }
    }
}
