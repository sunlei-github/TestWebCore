using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Const;
using WebApi.Common.Utitly;
using WebApi.Core.Entity.Resource;
using WebApi.Core.Enum.Resource;
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
            var tuple = GetWebApiCartoonUrl();
            string cartoonUrl = await CheckWebApiUrl(tuple.requestUrls);

            if (string.IsNullOrEmpty(cartoonUrl))
            {
                _logger.LogInformation("无可用的同步图片地址");
                return;
            }

            Queue<Action> taskQueue = new Queue<Action>();

            //定义任务
            Action taskAction =  () =>
            {
                Stream stream = null;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMsg = client.GetAsync(cartoonUrl).Result;
                    if (responseMsg.IsSuccessStatusCode)
                    {
                        stream = responseMsg.Content.ReadAsStreamAsync().Result;
                    }
                }

                string result = SourceUtitly.DownloadImage(stream, _configuration["DownloadDirectory"], SourceDirectoryConst.IMAGE).Result;
                RecodeSyncImg(stream, result, tuple.imageGroup).Wait();
            };

            for (int i = 0; i < 20; i++)
            {
                taskQueue.Enqueue(taskAction);
            }

            //同步任务 
            var result = Parallel.ForEach(taskQueue, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, item =>
             {
                 item.Invoke();
             });

            var dd = result.IsCompleted;
        }

        /// <summary>
        /// 下载的图片插入一条数据
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="result"></param>
        /// <param name="imageGroup"></param>
        /// <returns></returns>
        private async Task RecodeSyncImg(Stream stream, string result, ImageGroupEnum imageGroup)
        {
            DbImageResource dbImageResource = new DbImageResource
            {
                DownloadCount = 0,
                CanDownloaded = true,
                CreateTime = DateTime.Now,
                ImageGroup = imageGroup,
                IsShared = true,
                LastModifionTime = DateTime.Now,
                ResourceLocation = result,
                VisitCount = 0,
                ResourceSize = stream?.Length ?? 0
            };

            await _dbImageRepository.InsertEntity(dbImageResource);
        }

        private (string requestUrls, ImageGroupEnum imageGroup) GetWebApiCartoonUrl()
        {
            return (_configuration.GetSection("SyncResourceAdress:Image:Cartoon").Value, ImageGroupEnum.Cartoon);
        }

        private (string requestUrls, ImageGroupEnum imageGroup) GetWebApiGameUrl()
        {
            return (_configuration.GetSection("SyncResourceAdress:Image:Game").Value, ImageGroupEnum.Game);
        }

        private async Task<string> CheckWebApiUrl(string urlSerction)
        {
            List<string> requestUrls = urlSerction.Split('~').ToList();

            foreach (var requestUrl in requestUrls)
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMsg = await client.GetAsync(requestUrl);
                    if (responseMsg.IsSuccessStatusCode)
                    {
                        return requestUrl;
                    }
                }
            }

            return string.Empty;
        }

        public string TestJob()
        {
            _logger.LogInformation("Aaaaaaaaaaaaaaaaaaaaaaa");
            return DateTime.Now.ToString();
        }


    }
}
