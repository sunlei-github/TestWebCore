using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common.Log;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private ILogger _logger = null;
        private ILoggerFactory _loggerFactory;

        /// <summary>
        /// 记录日志注入 ILogger 和 ILoggerFactory 都可以
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="loggerFactory"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Redirect Swagger  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedirectResult Get()
        {
            var logger = _loggerFactory.CreateLogger<WeatherForecastController>();
            logger.LogWarning("跳转到Swagger");

            return Redirect("/swagger/index.html");
        }
    }
}
