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

    }
}
