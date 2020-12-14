using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.Redis
{
    /// <summary>
    /// Redis 字符串类型的接口
    /// 存放字符串类型的数据  如果存放的反序列化的数据 可能会因为转义字符报错  如果要存放对象 可以使用泛型的方法 存放 不会出现转义的问题
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

        /// <summary>
        /// 获取所有的key
        /// </summary>
        /// <returns></returns>
        List<string> GetAllKeys();


        /// <summary>
        /// 移除对应的key
        /// </summary>
        /// <param name="keys"></param>
        void RemoveKey(params string[] keys);

        /// <summary>
        /// 重新命名Key
        /// </summary>
        /// <param name="oldKey"></param>
        /// <param name="newKey"></param>
        void RenameKey(string oldKey, string newKey);

        /// <summary>
        /// 添加对象 会自动序列化  不会出现转义字符报错的问题
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiredTime"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, DateTime expiredTime);

        /// <summary>
        /// 批量设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        bool SetAll<T>(Dictionary<string, string> dictionary);

        /// <summary>
        /// 向key 追加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long Append(string key, string value);

        /// <summary>
        /// 根据key 自增1
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long IncrementValue(string key);

        /// <summary>
        /// 根据key  自增count
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        long IncrementValueBy(string key, int count);

        /// <summary>
        /// 根据key 自减1
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long DecrementValue(string key);

        /// <summary>
        /// 根据key 自减count
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        long DecrementValueBy(string key, int count);

    }
}
