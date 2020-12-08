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
    public class ImageSourceController : WebApiBaseController
    {
        private IImageServices _imageServices = null;

        public ImageSourceController(IImageServices imageServices)
        {
            _imageServices = imageServices;
        }

        /// <summary>
        /// 上传单个图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public UploadResourceOuput UploadImage(IFormFile file)
        {
            return _imageServices.UploadImage(file);
        }

        /// <summary>
        /// 批量上传图片
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public UploadResourcesOuput UploadImages(List<IFormFile> files)
        {
            return _imageServices.UploadImages(files);
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<FileStreamResult> DownloadImage(DownResourceInput input)
        {
            var result = await _imageServices.DownloadImage(input);

            return CreateFileStreamResult(result, input.FileName);
        }

    }
}
