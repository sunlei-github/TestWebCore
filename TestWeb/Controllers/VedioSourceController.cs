using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using WebApi.Common.Utitly;
using WebApi.Common.Const;
using Microsoft.Extensions.Configuration;
using WebApi.Core.Resut;
using WebApi.IApplication.IServices.IResource;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.Dto.Resource;

namespace WebApi.Controllers
{
    public class VedioSourceController : WebApiBaseController
    {
        private IVedioServices _vedioServices = null;

        public VedioSourceController(IVedioServices vedioServices)
        {
            _vedioServices = vedioServices;
        }

        /// <summary>
        /// 上传单个视频
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public UploadResourceOuput UploadImage(IFormFile file)
        {
            return _vedioServices.UploadVedio(file);
        }

        /// <summary>
        /// 批量上传视频
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public UploadResourcesOuput UploadImages(List<IFormFile> files)
        {
            return _vedioServices.UploadVedios(files);
        }

        /// <summary>
        /// 下载视频
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<FileStreamResult> DownloadMusic(DownResourceInput input)
        {
            var result = await _vedioServices.DownloadVedio(input);

            return CreateFileStreamResult(result, input.FileName);
        }
    }
}
