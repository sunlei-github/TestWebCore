﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Entity.HotResource;
using WebApi.Core.Entity.User;
using WebApi.Core.Enum.Resource;

namespace WebApi.Core.Entity.Resource
{
    public class DbImageResource : IResource
    {

        public long ResourceSize { set; get; }

        public string ResourceLocation { set; get; }

        public bool CanDownloaded { set; get; }

        public bool IsShared { set; get; }

        public long DownloadCount { set; get; }

        public long VisitCount { set; get; }

        public string Title { set; get; }

        public ICollection< DbHotImageResourceUser> DbHotImageReSourceUsers { set; get; }

        /// <summary>
        /// 图片种类
        /// </summary>
        public ImageGroupEnum ImageGroup { set; get; }

        public int CreatorUserId { set; get; }

        public DateTime? CreateTime { set; get; }

        public int Id { set; get; }

        public bool IsDeleted { set; get; }

        public DateTime? DeletedTime { set; get; }

        public string Description { set; get; }

    }
}
