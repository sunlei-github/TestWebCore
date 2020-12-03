using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Resut
{
    /// <summary>
    /// ajax 上传文件的返回结果
    /// </summary>
    public class AjaxUplaodResult
    {
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { set; get; }

        /// <summary>
        /// 上传文件的相对路径
        /// </summary>
        public string FilePath { set; get; }
    }
}
