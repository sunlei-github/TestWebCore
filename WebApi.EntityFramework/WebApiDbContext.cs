using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entity.User;

namespace WebApi.EntityFramework
{
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
            modelBuilder.Entity<DbUser>().HasIndex(c => c.Name);
        }

        #region Entity
        public DbSet<DbAccountUser> DbAccountUsers { set; get; }

        public DbSet<DbUser> DbUsers { set; get; } 
        #endregion
    }
}
