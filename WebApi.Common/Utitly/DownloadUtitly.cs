using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using WebApi.Common.Const;
using System.Net.Http.Headers;

namespace WebApi.Common.Utitly
{
    public class DownloadUtitly
    {
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        public static async Task<Stream> DownloadFile(string fileName, string filePath)
        {
            FileStream stream = null;
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                stream = fileInfo.Open(FileMode.Open, FileAccess.Read);
                await stream.FlushAsync();
            }

            return stream;
        }
    }
}
