using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Core.BaseEntity
{
    public interface IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Required]
        int Id { set; get; }
    }
}
