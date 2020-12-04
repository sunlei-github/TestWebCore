using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wlniao;

namespace WebApi
{
    /// <summary>
    /// BaseController 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebApiBaseController : ControllerBase
    {

        /// <summary>
        /// 创建FileStreamResult
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        protected virtual FileStreamResult CreateFileStreamResult(Stream stream, string fileName)
        {
            return new FileStreamResult(stream, new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName)));
        }
    }
}
