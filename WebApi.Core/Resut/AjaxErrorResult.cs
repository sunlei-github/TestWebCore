using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Resut
{
    /// <summary>
    /// ajax 请求的异常信息
    /// </summary>
    public class AjaxErrorResult
    {
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExpectionMessage { set; get; }

        /// <summary>
        /// 异常标题
        /// </summary>
        public string Title { set; get; }
    }
}
