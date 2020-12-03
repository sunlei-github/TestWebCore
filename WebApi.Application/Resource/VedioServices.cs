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
    public class VedioServices : BaseServices, IVedioServices
    {

        private IConfiguration _configuration = null;

        public VedioServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ResourceOuput UploadVedio(IFormFile file)
        {
            return new ResourceOuput
            {
                UplaodPath = base.UploadFile(file, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_VEDIO)
            };
        }

        public ResourcesOuput UploadVedios(List<IFormFile> files)
        {
            return new ResourcesOuput
            {
                UplaodPaths = base.UploadFiles(files, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_VEDIO)
            };
        }

    }
}
