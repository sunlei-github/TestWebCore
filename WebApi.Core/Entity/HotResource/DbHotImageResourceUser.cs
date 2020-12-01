using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using WebApi.Core.Entity.Resource;

namespace WebApi.Core.Entity.HotResource
{
    /// <summary>
    /// 图片和图片三连表的中间表
    /// </summary>
    public class DbHotImageResourceUser : IEntity
    {
        public int Id { get; set; }

        public int DbHotImageReSourceId { set; get; }

        public DbHotImageResource DbHotImageResource { set; get; }

        public int DbImageResourceId { set; get; }

        public DbImageResource DbImageResource { set; get; }
    }
}
