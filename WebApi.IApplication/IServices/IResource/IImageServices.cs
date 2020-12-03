using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.Dto.Account;

namespace WebApi.IApplication.IServices.IResource
{
    public interface IImageServices
    {
        /// <summary>
        /// 上传单个图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        ResourceOuput UploadImage(IFormFile file);

        /// <summary>
        /// 上传多个图片
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        ResourcesOuput UploadImages(List<IFormFile> files);
    }
}
