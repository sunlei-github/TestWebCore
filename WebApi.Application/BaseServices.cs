using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Common.Utitly;

namespace WebApi.Application
{
    public class BaseServices
    {

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="uploadDiretory"></param>
        /// <param name="fileTypeName"></param>
        /// <returns></returns>
        protected virtual string UploadFile(IFormFile file,string uploadDiretory,string fileTypeName)
        {
            return SourceUtitly.UploadFile(file, uploadDiretory, fileTypeName);
        }

        /// <summary>
        /// 批量上传文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="uploadDiretory"></param>
        /// <param name="fileTypeName"></param>
        /// <returns></returns>
        protected virtual List<string> UploadFiles(List<IFormFile> files, string uploadDiretory, string fileTypeName)
        {
            List<string> results = new List<string>();

            foreach (var file in files)
            {
                string result = UploadFile(file, uploadDiretory, fileTypeName);

                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// 创建登陆用户对应的Redis的 key  key组成  CurerentUser_+{userId}
        /// </summary>
        /// <returns></returns>
        protected string CreateCurentUserRedisKey(int  userId)
        {
            return $"CurerentUser_{userId}";
        }
    }
}
