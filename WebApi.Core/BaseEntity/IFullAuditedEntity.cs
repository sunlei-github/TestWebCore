using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Core.BaseEntity
{
    public interface IFullAuditedEntity : IAuditedEntity
    {
        /// <summary>
        /// 创建人姓名
        /// </summary>
        [StringLength(50)]
        string CreatorName { set; get; }

        /// <summary>
        /// 最后更新人姓名
        /// </summary>
        [StringLength(50)]
        string LastModifierUserName { set; get; }
    }
}
