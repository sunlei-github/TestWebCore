using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Const;
using WebApi.Common.Utitly;
using WebApi.Core.Entity.Resource;
using WebApi.IApplication.IServices.IHangefire;
using WebApi.Repository.Repository;

namespace WebApi.Application.HangfireTask
{

    public class HangefireServices : BaseServices, IHangefireServices
    {

        private ILogger _logger = null;
        private IConfiguration _configuration = null;
        private IRepositoryServices<DbImageResource> _dbImageRepository;

        public HangefireServices(IConfiguration configuration, IRepositoryServices<DbImageResource> dbImageRepository, ILogger<HangefireServices> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _dbImageRepository = dbImageRepository;
        }

        public async Task DownloadImage()
        {
            Stream stream = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMsg = await client.GetAsync("https://acg.yanwz.cn/api.php");
                if (responseMsg.IsSuccessStatusCode)
                {
                    stream = await responseMsg.Content.ReadAsStreamAsync();
                }
            }

            string result = await SourceUtitly.DownloadImage(stream, _configuration["DownloadDirectory"], SourceDirectoryConst.IMAGE);

        }

        public string TestJob()
        {
            _logger.LogInformation("Aaaaaaaaaaaaaaaaaaaaaaa");
            return DateTime.Now.ToString();
        }

    }
}
