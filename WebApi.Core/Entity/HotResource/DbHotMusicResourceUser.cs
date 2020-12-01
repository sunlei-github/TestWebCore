using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Entity.Resource;

namespace WebApi.Core.Entity.HotResource
{
    /// <summary>
    /// 音乐和音乐三连表的中间表
    /// </summary>
    public class DbHotMusicResourceUser : IEntity
    {
        public int Id { get; set; }

        public int DbHotMusicReSourceId { set; get; }

        public DbHotMusicResource DbHotMusicResource { set; get; }

        public int DbMusicResourceId { set; get; }

        public DbMusicResource DbMusicResource { set; get; }
    }
}
