using AutoMapper;
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

        private IHangefireServices _hangefireServices = null;

        private IMapper _mapper = null;

        public TestController(IHangefireServices hangefireServices, IMapper mapper)
        {
            _hangefireServices = hangefireServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task DownloadImage()
        {
            await _hangefireServices.DownloadImage();
        }

        [HttpGet]
        public void TestRedis()
        {
            //RedisStringServices redis = new RedisStringServices();
            //redis.Test();

            //RedisHashServices redis = new RedisHashServices();
            //redis.Test();

            //RedisListServices redis = new RedisListServices();
            //redis.Test();

            //RedisSetServices redis = new RedisSetServices();
            //redis.Test();

        }

        [HttpGet]
        public void TestMapper()
        {
            People people = new People
            {
                Birthday = DateTime.Now,
                Id = 1,
                Name = "Tom",
                Old = 20
            };

            var cp = _mapper.Map<ChinesePeople>(people);

            var dd = _mapper.Map<People>(cp);
        }


        public class People
        {
            public int Id { set; get; }

            public string Name { set; get; }

            public double Old { set; get; }

            public DateTime Birthday { set; get; }
        }

        public class ChinesePeople
        {
            public int Id { set; get; }

            public string Name { set; get; }

            public double Old { set; get; }

            public DateTime Birthday { set; get; }
        }
    }
}
