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
    public interface IMusicServices
    {
        /// <summary>
        /// 上传单个音乐
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        UploadResourceOuput UploadMusic(IFormFile file);

        /// <summary>
        /// 上传多个音乐
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        UploadResourcesOuput UploadMusics(List<IFormFile> files);

        /// <summary>
        /// 下载音乐
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Stream> DownloadMusic(DownResourceInput input);
    }
}
