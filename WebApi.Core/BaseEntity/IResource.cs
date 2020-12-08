using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Core.BaseEntity
{
    /// <summary>
    /// 资源接口
    /// </summary>
    public interface IResource: IFullAuditedEntity
    {
        /// <summary>
        /// 资源大小
        /// </summary>
        long ResourceSize { set; get; }

        /// <summary>
        /// 资源地址
        /// </summary>
        string ResourceLocation { set; get; }

        /// <summary>
        /// 是否允许下载 控制其他人是否可以下载该资源
        /// </summary>
        bool CanDownloaded { set; get; }

        /// <summary>
        /// 下载次数
        /// </summary>
        long DownloadCount { set; get; }

        /// <summary>
        /// 是否共享  控制其他人是否可以看见该资源
        /// </summary>
        bool IsShared { set; get; }

        /// <summary>
        /// 观看次数
        /// </summary>
        long VisitCount { set; get; }

        /// <summary>
        /// 资源名称
        /// </summary>
        [StringLength(50)]
        string Title { set; get; }

        [StringLength(200)]
        string Description { set; get; }
    }
}
