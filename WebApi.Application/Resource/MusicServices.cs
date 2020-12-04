using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Const;
using WebApi.Common.Utitly;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.Dto.Resource;
using WebApi.IApplication.IServices.IResource;

namespace WebApi.Application.Resource
{
    public class MusicServices : BaseServices, IMusicServices
    {

        private IConfiguration _configuration = null;

        public MusicServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Stream> DownloadMusic(DownResourceInput input)
        {
            return await DownloadUtitly.DownloadFile(input.FilePath);
        }

        public UploadResourceOuput UploadMusic(IFormFile file)
        {
            return new UploadResourceOuput
            {
                UplaodPath = base.UploadFile(file, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_MUSIC)
            };
        }

        public UploadResourcesOuput UploadMusics(List<IFormFile> files)
        {
            return new UploadResourcesOuput
            {
                UplaodPaths = base.UploadFiles(files, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_MUSIC)
            };
        }

    }
}
