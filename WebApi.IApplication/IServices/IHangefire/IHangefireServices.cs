using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IApplication.IServices.IHangefire
{
    public interface IHangefireServices
    {
        string TestJob();


        Task DownloadImage();
    }
}
