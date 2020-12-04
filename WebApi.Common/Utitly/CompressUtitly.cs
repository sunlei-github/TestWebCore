using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebApi.Common.Const;

namespace WebApi.Common.Utitly
{
    /// <summary>
    /// 压缩文件
    /// </summary>
    public class CompressUtitly
    {
        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="zipDirectory">压缩的存放路径</param>
        /// <param name="targetZipDirectory">是否存放到指定目录</param>
        public static void CompressFile(string filePath, string zipDirectory, string password,string targetZipDirectory = null)
        {
            using (ZipFile zipFile = new ZipFile(Encoding.UTF8))
            {
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string zipFileName = fileInfo.Name.Replace(fileInfo.Extension, FileConst.ZIP);
                    string zipFilePath = Path.Combine(zipDirectory, zipFileName);

                    //将压缩文件添加到指定目录
                    if (!string.IsNullOrEmpty(targetZipDirectory))
                    {
                        PathUtitly.EnsurePhysicalPath(targetZipDirectory);
                        zipDirectory = targetZipDirectory;
                        zipFilePath = Path.Combine(targetZipDirectory, zipFileName);
                    }
                    if (!string.IsNullOrEmpty(password))
                    {
                        zipFile.Password = password;
                    }

                    zipFile.AddDirectory(zipDirectory);

                    zipFile.AddFile(filePath);
                    zipFile.Save(zipFilePath);
                }
            }
        }
    }
}
