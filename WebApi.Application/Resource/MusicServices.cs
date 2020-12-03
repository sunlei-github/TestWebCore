using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Common.Const;
using WebApi.IApplication.Dto.Account;
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

        public ResourceOuput UploadMusic(IFormFile file)
        {
            return new ResourceOuput
            {
                UplaodPath = base.UploadFile(file, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_MUSIC)
            };
        }

        public ResourcesOuput UploadMusics(List<IFormFile> files)
        {
            return new ResourcesOuput
            {
                UplaodPaths = base.UploadFiles(files, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_MUSIC)
            };
        }

    }
}
