using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebApi.Common.Utitly
{
    public class FileUtitly
    {
        /// <summary>
        /// 创建guid的文件名称
        /// </summary>
        /// <param name="DiretoryPath"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static string PrepareRelativeUploadFile(string DiretoryPath,string fileExtension)
        {

            string guid = GuidUtitly.CreateGuid();
            string guidFilleName = $"{guid}{fileExtension}";
            string filePath = Path.Combine(DiretoryPath, guidFilleName);

            return filePath;
        }

        /// <summary>
        /// 获取文件的全路径
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        public static string GetFullUploadFile(string relativeFilePath)
        {
            if (!File.Exists(relativeFilePath))
            {
                var stream = File.Create(relativeFilePath);
                stream.Close();
                stream.Dispose();
            }

            return Path.GetFullPath(relativeFilePath);
        }

    }
}
