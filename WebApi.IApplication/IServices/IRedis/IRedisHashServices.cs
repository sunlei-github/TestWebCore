using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.IRedis
{
    /// <summary>
    /// Redis 哈希类型的接口 
    /// 类似于一个字典集合
    /// </summary>
    public interface IRedisHashServices
    {
        /// <summary>
        /// 设置单个hash 值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetValueInHash(string hashId, string key, string value);

        /// <summary>
        /// 如果hashId 和 key 不存在 则设置值 
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetValueInHashIfNotExists(string hashId, string key, string value);

        /// <summary>
        /// 设置hashId 对应的字典值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="keyValuePairs"></param>
        void SetDictionaryInHash(string hashId, Dictionary<string, string> keyValuePairs);

        /// <summary>
        /// 根据HashId 和 key 获取值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValuesFromHash(string hashId, string key);

        /// <summary>
        /// 根据HashId 获取对应的字典值
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        Dictionary<string, string> GetDictionaryFromHash(string hashId);

        /// <summary>
        /// 获取hashId 存放的对应的值的数量
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        long GetCountFromHash(string hashId);

        /// <summary>
        /// 根据hashId 获取值的集合
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        List<string> GetListValueFromHash(string hashId);

        /// <summary>
        /// 根据hashId 获取key的集合
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        List<string> GetListKeyFromHash(string hashId);

        /// <summary>
        /// 根据hashId 和 多个对应的key  获取多对应的值的集合
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        List<string> GetValuesFromHash(string hashId, params string[] keys);

        /// <summary>
        /// 根据hashId 判断对应的key 是否存在
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HashContainsEntry(string hashId, string key);

        /// <summary>
        /// 根骨hashId  将对应的值 转换成字典 
        /// </summary>
        /// <param name="hashId"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> ScanAllHashEntries(string hashId);

        /// <summary>
        /// 根据hashId 和 key 移除对应的值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool RemoveValueFromHash(string hashId, string key);

        /// <summary>
        /// 存放对象 存放的对象必须有id  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void StoreAsHash<T>(T entity);

        /// <summary>
        /// 根据id 返回对象
        /// </summary>
        T GetFromHash<T>(object id);

        /// <summary>
        /// 给hashid数据集key的value增加incrementBy值，返回相加后的数据
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="incrementBy"></param>
        /// <returns></returns>
        long IncrementValueInHash(string hashId, string key, int incrementBy);
    }
}
