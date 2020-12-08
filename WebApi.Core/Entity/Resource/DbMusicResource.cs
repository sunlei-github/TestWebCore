using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Entity.HotResource;
using WebApi.Core.Entity.User;
using WebApi.Core.Enum.Resource;

namespace WebApi.Core.Entity.Resource
{
    public class DbMusicResource :  IResource
    {

        public long ResourceSize { set; get; }

        public string ResourceLocation { set; get; }

        public bool CanDownloaded { set; get; }

        public bool IsShared { set; get; }

        public long DownloadCount { set; get; }

        public long VisitCount { set; get; }

        public string Title { set; get; }

        public int DbUserId { set; get; }

        public DbUser DbUser { set; get; }

        /// <summary>
        /// 图片种类
        /// </summary>
        public MusicGroupEnum MusicGroup { set; get; }

        public ICollection<DbHotMusicResourceUser> DbHotMusicResourceUsers { set; get; }

        public string CreatorName { set; get; }

        public string LastModifierUserName { set; get; }

        public int CreatorUserId { set; get; }

        public DateTime? CreateTime { set; get; }

        public int? LastModifierUserId { set; get; }

        public DateTime LastModifionTime { set; get; }

        public int Id { set; get; }

        public bool IsDeleted { set; get; }

        public DateTime? DeletedTime { set; get; }

        public string Description { set;get; }
    }
}