using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Redis;
using WebApi.IApplication.IServices.IHangefire;

namespace WebApi.Controllers
{
    public class TestController : WebApiBaseController
    {

        private IHangefireServices _hangefireServices;

        public TestController(IHangefireServices hangefireServices)
        {
            _hangefireServices = hangefireServices;
        }

        [HttpGet]
        public async Task DownloadImage()
        {
             await _hangefireServices.DownloadImage();
        }

        [HttpGet]
        public void TestRedis()
        {
            RedisStringServices redis = new RedisStringServices();
            redis.Test();
        }
    }
}
