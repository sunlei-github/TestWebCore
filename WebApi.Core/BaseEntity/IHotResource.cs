using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.BaseEntity
{
    public interface IHotResource : IAuditedEntity
    {
        /// <summary>
        /// 是否投币
        /// </summary>
        bool PayCoin { set; get; }

        /// <summary>
        /// 是否点赞
        /// </summary>
        bool ClickLike { set; get; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        bool Collect { set; get; }
    }
}
