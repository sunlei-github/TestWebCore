using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.Dto.Resource
{
    public class DownResourceInput
    {
        /// <summary>
        /// 下载的路径
        /// </summary>
        public string FilePath { set; get; }

        /// <summary>
        /// 下载的文件
        /// </summary>
        public string FileName { set; get; }
    }
}
