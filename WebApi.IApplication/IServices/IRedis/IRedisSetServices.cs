using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.IRedis
{
    /// <summary>
    /// set  
    /// 存放的是一个集合  用hash表来保存字符串的唯一性，没有先后顺序 
    /// </summary>
    public interface IRedisSetServices
    {
        /// <summary>
        /// 添加一个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddValue(string key, string value);

        /// <summary>
        /// 添加多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        void AddValues(string key, List<string> values);

        /// <summary>
        /// 获取一个随机值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetRandomValue(string key);

        /// <summary>
        /// 获取所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        HashSet<string> GetAllValues(string key);

        /// <summary>
        /// 获取所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long GetValueCount(string key);

        /// <summary>
        /// 移除对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void RemoveValue(string key, string value);

        /// <summary>
        /// 移除一个集合中的的值 添加到另一个集合中
        /// </summary>
        /// <param name="fromKey"></param>
        /// <param name="toKey"></param>
        /// <param name="value"></param>
        void MoveBetweenSets(string fromKey, string toKey, string value);
  
        /// <summary>
        /// 返回并集
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        HashSet<string> GetUnionFromSets(params string[] keys);

        /// <summary>
        /// 返回交集
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        HashSet<string> GetIntersectFromSets(params string[] keys);
      
        /// <summary>
        /// 返回差集
        /// </summary>
        /// <param name="fromKey"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        HashSet<string> GetDifferencesFromSet(string fromKey, params string[] keys);

        /// <summary>
        /// 返回的并集 存放在一个新的集合中
        /// </summary>
        /// <param name="intoKey"></param>
        /// <param name="keys"></param>
         void StoreUnionFromSets(string intoKey, params string[] keys);

        /// <summary>
        /// 返回的差集 存放在一个集合中
        /// </summary>
        /// <param name="fromKey"></param>
        /// <param name="intoKey"></param>
        /// <param name="keys"></param>
        void StoreDifferencesFromSet(string fromKey, string intoKey, params string[] keys);

        /// <summary>
        /// 返回的交集 存放在一个集合中
        /// </summary>
        /// <param name="intoKey"></param>
        /// <param name="keys"></param>
        void StoreIntersectFromSets(string intoKey, params string[] keys);
     
    }
}
