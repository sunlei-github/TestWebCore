using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.Dto.Account;

namespace WebApi.IApplication.IServices.IResource
{
    public interface IVedioServices
    {
        /// <summary>
        /// 上传单个视频
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        ResourceOuput UploadVedio(IFormFile file);

        /// <summary>
        /// 上传多个视频
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        ResourcesOuput UploadVedios(List<IFormFile> files);
    }
}
