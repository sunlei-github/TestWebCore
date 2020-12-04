using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.IApplication.Dto.Resource;

namespace WebApi.IApplication.IServices.IResource
{
    public interface IVedioServices
    {
        /// <summary>
        /// 上传单个视频
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        UploadResourceOuput UploadVedio(IFormFile file);

        /// <summary>
        /// 上传多个视频
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        UploadResourcesOuput UploadVedios(List<IFormFile> files);

        /// <summary>
        /// 下载视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Stream> DownloadVedio(DownResourceInput input);
    }
}
