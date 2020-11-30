using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        /// <summary>
        /// WeatherForecast  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedirectResult Get()
        {
            return Redirect("/swagger/index.html");
        }
    }
}
