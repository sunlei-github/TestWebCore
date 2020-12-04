using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.Dto.Resource;

namespace WebApi.IApplication.IServices.IResource
{
    public interface IImageServices
    {
        /// <summary>
        /// 上传单个图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        UploadResourceOuput UploadImage(IFormFile file);

        /// <summary>
        /// 上传多个图片
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        UploadResourcesOuput UploadImages(List<IFormFile> files);

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Stream> DownloadImage(DownResourceInput input);
    }
}
