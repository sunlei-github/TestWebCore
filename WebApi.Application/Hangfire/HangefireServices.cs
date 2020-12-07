using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.IApplication.IServices.IHangefire;

namespace WebApi.Application.HangfireTask
{

    public class HangefireServices : BaseServices, IHangefireServices
    {

        private ILogger _logger = null;

        public HangefireServices(ILogger<HangefireServices> logger)
        {
            _logger = logger;
        }

        public string TestJob()
        {
            _logger.LogInformation("Aaaaaaaaaaaaaaaaaaaaaaa");
            return DateTime.Now.ToString();
        }

    }
}
