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
    public class MusicSourceController : WebApiBaseController
    {
        private IMusicServices _musicServices = null;

        public MusicSourceController(IMusicServices musicServices)
        {
            _musicServices = musicServices;
        }

        /// <summary>
        /// 上传单个音乐
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public UploadResourceOuput UploadImage(IFormFile file)
        {
            return _musicServices.UploadMusic(file);
        }

        /// <summary>
        /// 批量上传音乐
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public UploadResourcesOuput UploadImages(List<IFormFile> files)
        {
            return _musicServices.UploadMusics(files);
        }

        /// <summary>
        /// 下载音乐
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<FileStreamResult> DownloadMusic(DownResourceInput input)
        {
            var result = await _musicServices.DownloadMusic(input);

            return CreateFileStreamResult(result, input.FileName);
        }
    }
}
