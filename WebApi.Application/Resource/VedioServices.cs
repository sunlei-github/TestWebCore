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
    public class VedioServices : BaseServices, IVedioServices
    {

        private IConfiguration _configuration = null;

        public VedioServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Stream> DownloadVedio(DownResourceInput input)
        {
            return await DownloadUtitly.DownloadFile(input.FilePath);
        }

        public UploadResourceOuput UploadVedio(IFormFile file)
        {
            return new UploadResourceOuput
            {
                UplaodPath = base.UploadFile(file, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_VEDIO)
            };
        }

        public UploadResourcesOuput UploadVedios(List<IFormFile> files)
        {
            return new UploadResourcesOuput
            {
                UplaodPaths = base.UploadFiles(files, _configuration["UploadDiretory"], UploadSourceConst.UPLOAD_VEDIO)
            };
        }

    }
}
