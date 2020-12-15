using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApi.Core.Enum.Resource
{
    public enum MusicGroupEnum
    {

        /// <summary>
        /// 古风音乐
        /// </summary>
        [Description("古风")]
        Ancient =1,

        /// <summary>
        /// 现代音乐
        /// </summary>
        [Description("现代")]
        Modern =2,

    } 
}
