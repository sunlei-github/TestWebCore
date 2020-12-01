using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entity.HotResource;
using WebApi.Core.Entity.Resource;
using WebApi.Core.Entity.User;

namespace WebApi.EntityFramework
{
    /// <summary>
    /// 该类只写数据库实体
    /// </summary>
    public partial class WebApiDbContext
    {

        public DbSet<DbAccountUser> DbAccountUsers { set; get; }

        public DbSet<DbUser> DbUsers { set; get; }

        public DbSet<DbImageResource> DbImageResources { set; get; }

        public DbSet<DbHotImageResourceUser> DbHotImageReSourceUsers { set; get; }

        public DbSet<DbHotImageResource> DbHotImageResources { set; get; }

        public DbSet<DbMusicResource> DbMusicResources { set; get; }

        public DbSet<DbHotMusicResourceUser> DbHotMusicResourceUsers { set; get; }

        public DbSet<DbHotMusicResource> DbHotMusicResources { set; get; }

        public DbSet<DbVedioResource> DbVedioResources { set; get; }

        public DbSet<DbHotVedioResource> DbHotVedioResources { set; get; }

        public DbSet<DbHotVedioResourceUser> HotVedioResourceUsers { set; get; }


    }
}
