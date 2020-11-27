using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.BaseEntity
{
    public interface IAuditedEntity : IEntity, IDelete
    {
        /// <summary>
        /// 创建人Id
        /// </summary>
        int CreatorUserId { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreateTime { set; get; }

        /// <summary>
        /// 最后更新人Id
        /// </summary>
        int? LastModifierUserId { set; get; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        DateTime LastModifionTime { set; get; }

    }
}
