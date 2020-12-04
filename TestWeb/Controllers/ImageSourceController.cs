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
        public ResourceOuput UploadImage(IFormFile file)
        {
            return _imageServices.UploadImage(file);
        }

        /// <summary>
        /// 批量上传图片
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public ResourcesOuput UploadImages(List<IFormFile> files)
        {
            return _imageServices.UploadImages(files);
        }


    }
}
