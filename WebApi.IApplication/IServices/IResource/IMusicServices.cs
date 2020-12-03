using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.Dto.Account;

namespace WebApi.IApplication.IServices.IResource
{
    public interface IMusicServices
    {
        /// <summary>
        /// 上传单个音乐
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        ResourceOuput UploadMusic(IFormFile file);

        /// <summary>
        /// 上传多个音乐
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        ResourcesOuput UploadMusics(List<IFormFile> files);
    }
}
