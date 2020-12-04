using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WebApi.Common.Utitly
{
    public class PathUtitly
    {
        /// <summary>
        /// 创建日期路径
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static string PrepareDateUploadPath(string basePath)
        {
            string relativePath = Path.Combine(basePath, CreateDataDiretory());
            EnsurePhysicalPath(relativePath);

            return relativePath;
        }

        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        /// <param name="path"></param>
        public static void EnsurePhysicalPath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 替换路径
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="oldStr"></param>
        /// <param name="newStr"></param>
        /// <returns></returns>
        public static string ReplacePath(string fullPath,string oldStr,string newStr)
        {
            return fullPath.Replace(oldStr, newStr);
        }

        /// <summary>
        /// 创建日期文件夹
        /// </summary>
        /// <returns></returns>
        private static string CreateDataDiretory()
        {
            return $"{DateTime.Now.Date.ToLongDateString()}";
        }
    }
}
