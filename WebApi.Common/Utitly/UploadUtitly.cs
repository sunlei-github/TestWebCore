using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Resut;
using System.IO;

namespace WebApi.Common.Utitly
{
    public class UploadUtitly
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="basePath"></param>
        /// <param name="uploadDirectoy"></param>
        /// <returns></returns>
        public static string UploadFile(IFormFile file,string basePath,string uploadDirectoy)
        {
            string result = "上传失败";
            if (file == null)
            {
                return result;
            }

            if (file.Length < 0)
            {
                return result;
            }

            string baseRelativePath = Path.Combine(basePath, uploadDirectoy);
            string relativeUploadPath = PathUtitly.PrepareDateUploadPath(baseRelativePath);
            string relativeFilePath = FileUtitly.PrepareRelativeUploadFile(relativeUploadPath, file.FileName);
            string fileFullPath = FileUtitly.GetFullUploadFile(relativeFilePath);

            using (FileStream fileStream =new FileStream (fileFullPath, FileMode.Create,FileAccess.ReadWrite))
            {
                file.CopyTo(fileStream);
                result = relativeFilePath;
            }

            return relativeFilePath;
        }
    }
}
