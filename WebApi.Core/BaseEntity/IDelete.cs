using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.BaseEntity
{
    public interface IDelete
    {
        /// <summary>
        /// 是否 删除
        /// </summary>
        bool IsDeleted { set; get; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeletedTime { set; get; }
    }
}
