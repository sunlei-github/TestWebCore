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
    /// 该类只是对实体进行配置
    /// </summary>
    public partial class WebApiDbContext : DbContext
    {

        public WebApiDbContext() { }

        public WebApiDbContext(DbContextOptions options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=47.98.50.115;port=3306;database=WebCore;uid=root;password=123456;Charset=utf8;Convert Zero Datetime=True ;Allow Zero Datetime=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置索引
            modelBuilder.Entity<DbUser>().HasIndex(c => c.FullName);
            //计算列
            //modelBuilder.Entity<DbUser>().Property(c => c.First_Name).HasComputedColumnSql("[First_Name] + [Last_Name]");

            //一对一
            modelBuilder.Entity<DbAccountUser>().HasOne(c => c.DbUser).WithOne(c => c.DbAccountUser).HasForeignKey<DbUser>(c => c.User_AccountUser_Id);

            #region 多对多   通过两个一对多形成 多对多的配置
            modelBuilder.Entity<DbHotImageResourceUser>().HasOne(c => c.DbHotImageResource).WithMany(c => c.DbHotImageReSourceUsers)
                    .HasForeignKey(c => c.DbHotImageReSourceId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DbHotImageResourceUser>().HasOne(c => c.DbImageResource).WithMany(c => c.DbHotImageReSourceUsers)
                .HasForeignKey(c => c.DbImageResourceId).OnDelete(DeleteBehavior.Cascade);
            #endregion
            modelBuilder.Entity<DbImageResource>().HasIndex(c => c.Title);
            //插入新数据时  主键自增
            modelBuilder.Entity<DbImageResource>().Property(c => c.Id).ValueGeneratedOnAdd();
            //计算默认值
            //modelBuilder.Entity<DbImageResource>().Property(c => c.CreateTime).HasDefaultValueSql("new now()");

            modelBuilder.Entity<DbHotVedioResourceUser>().HasOne(c => c.DbHotVedioResource).WithMany(c => c.DbHotVedioResourceUsers)
                .HasForeignKey(c => c.DbHotVedioReSourceId);
            modelBuilder.Entity<DbHotVedioResourceUser>().HasOne(c => c.DbVedioResource).WithMany(c => c.DbHotVedioResourceUsers)
                 .HasForeignKey(c => c.DbVedioResourceId);
            modelBuilder.Entity<DbVedioResource>().HasIndex(c => c.Title);
            modelBuilder.Entity<DbVedioResource>().Property(c => c.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<DbVedioResource>().Property(c => c.CreateTime).HasDefaultValueSql("new now()");

            modelBuilder.Entity<DbHotMusicResourceUser>().HasOne(c => c.DbHotMusicResource).WithMany(c => c.DbHotMusicResourceUsers)
               .HasForeignKey(c => c.DbHotMusicReSourceId);
            modelBuilder.Entity<DbHotMusicResourceUser>().HasOne(c => c.DbMusicResource).WithMany(c => c.DbHotMusicResourceUsers)
               .HasForeignKey(c => c.DbMusicResourceId);
            modelBuilder.Entity<DbMusicResource>().HasIndex(c => c.Title);
            modelBuilder.Entity<DbMusicResource>().Property(c => c.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<DbVedioResource>().Property(c => c.CreateTime).HasDefaultValueSql("new now()");

        }

    }
}
