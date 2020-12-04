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
        /// 压缩文件
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
                    PathUtitly.EnsurePhysicalPath(zipDirectory);
                    FileInfo fileInfo = new FileInfo(filePath);
                    string zipFileName = fileInfo.Name.Replace(fileInfo.Extension, FileConst.ZIP);

                    //将压缩文件添加到指定目录
                    if (!string.IsNullOrEmpty(targetZipDirectory))
                    {
                        PathUtitly.EnsurePhysicalPath(targetZipDirectory);
                        zipDirectory = targetZipDirectory;
                    }

                    string zipFilePath = Path.Combine(zipDirectory, zipFileName);
                    zipFile.Password = password;
                    zipFile.AddFile(filePath);

                    zipFile.Save(zipFilePath);
                }
                else
                    throw new Exception($"压缩文件出错，找不到对应的文件{filePath}");
            }
        }

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="zipDirectory"></param>
        /// <param name="password"></param>
        /// <param name="targetZipDirectory"></param>
        public static void CompressDirectory(string directory,string zipDirectory,string password,string targetZipDirectory = null)
        {
            using (ZipFile zipFile=new ZipFile (Encoding.UTF8))
            {
                if (Directory.Exists(directory))
                {
                    PathUtitly.EnsurePhysicalPath(zipDirectory);
                    //压缩文件夹的名称
                    string zipDirctoryName = GuidUtitly.CreateGuid() + FileConst.ZIP;
                    zipFile.AddDirectory(directory);

                    zipFile.Password = password;
                    if (!string.IsNullOrEmpty(targetZipDirectory))
                    {
                        PathUtitly.EnsurePhysicalPath(targetZipDirectory);
                        zipDirectory = targetZipDirectory;
                    }
                    string zipPath = Path.Combine(zipDirectory, zipDirctoryName);
                    zipFile.Password = password;

                    //保存
                    zipFile.Save(zipPath);
                }
                else
                    throw new Exception($"压缩文件出错，找不到对应的文件{directory}");
            }
        }

    }
}
