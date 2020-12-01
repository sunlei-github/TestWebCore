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
    public class DbHotVedioResourceUser : IEntity
    {
        public int Id { get; set; }

        public int DbHotVedioReSourceId { set; get; }

        public DbHotVedioResource DbHotVedioResource { set; get; }

        public int DbVedioResourceId { set; get; }

        public DbVedioResource DbVedioResource { set; get; }
    }
}
