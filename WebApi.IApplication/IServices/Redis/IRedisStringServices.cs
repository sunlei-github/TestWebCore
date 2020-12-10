using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.Redis
{
    /// <summary>
    /// Redis 字符串类型的接口
    /// </summary>
    public interface IRedisStringServices
    {

        /// <summary>
        /// 设置字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue(string key, string value);
    
        /// <summary>
        /// 批量设置字符串值
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="values"></param>
         void SetAllValue(IEnumerable<string> keys, IEnumerable<string> values);

        /// <summary>
        /// 如果存在Key 则设置字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
         bool SetValueIfExists(string key, string value);
  
        /// <summary>
        /// 如果不存在Key 则设置字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
         bool SetValueIfNotExists(string key, string value);

        /// <summary>
        /// 如果key存在 则设置新值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        bool Replace<T>(string key, T newValue);
  
    }
}
