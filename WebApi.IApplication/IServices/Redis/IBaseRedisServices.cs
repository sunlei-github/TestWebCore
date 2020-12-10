using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.Redis
{
    public interface IBaseRedisServices
    {
        /// <summary>
        /// 获取所有的Key
        /// </summary>
        /// <returns></returns>
        List<string> GetAllKeys();

        /// <summary>
        /// 清除对应的key
        /// </summary>
        void RemoveKey(params string[] key);

        /// <summary>
        /// 重命名key
        /// </summary>
        /// <param name="oldKey"></param>
        /// <param name="newKey"></param>
        void RenameKey(string oldKey, string newKey);
    }
}
