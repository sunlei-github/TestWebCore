using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Const;
using WebApi.Common.Utitly;
using WebApi.Core.Entity.Resource;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.Dto.Resource;
using WebApi.IApplication.IServices.IResource;
using WebApi.Repository.Repository;

namespace WebApi.Application.Resource
{
    public class ImageServices : BaseServices, IImageServices
    {

        private IConfiguration _configuration = null;
        private IRepositoryServices<DbImageResource> _dbImageRepository;

        public ImageServices(IConfiguration configuration, IRepositoryServices<DbImageResource> dbImageRepository)
        {
            _configuration = configuration;
            _dbImageRepository = dbImageRepository;
        }

        public async Task<Stream> DownloadImage(DownResourceInput input)
        {
            return await DownloadUtitly.DownloadFile(input.FilePath);
        }

        public UploadResourceOuput UploadImage(IFormFile file)
        {
            return new UploadResourceOuput
            {
                UplaodPath = base.UploadFile(file, _configuration["UploadDiretory"], SourceDirectoryConst.IMAGE)
            };
        }

        public UploadResourcesOuput UploadImages(List<IFormFile> files)
        {
            return new UploadResourcesOuput
            {
                UplaodPaths = base.UploadFiles(files, _configuration["UploadDiretory"], SourceDirectoryConst.IMAGE)
            };
        }

    }
}
