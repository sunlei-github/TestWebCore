using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.Redis
{
    /// <summary>
    /// zset  
    /// 是set的进阶版  可以将存放进去的数据 按照score进行排序
    /// </summary>
    public interface IRedisZSetServices
    {
        /// <summary>
        /// 添加值  并添加分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        bool AddValue(string key, string value, double score);

        /// <summary>
        /// 添加多个值   这些值的分数都是 score
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        bool AddValues(string key, List<string> values, double score);

        /// <summary>
        ///获取所有的值  正序
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<string> GetAllValues(string key);

        /// <summary>
        /// 获取所有的值  逆序
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<string> GetAllValuesDesc(string key);

        /// <summary>
        /// 获取所有的值 带分数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IDictionary<string, double> GetAllWithScoresFromSortedSet(string key);

        /// <summary>
        /// 根据key和value 获取索引值  正序
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long GetValueIndexInSortedSet(string key, string value);

        /// <summary>
        /// 根据key和value 获取索引值  倒叙
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        long GetValueIndexInSortedSetDesc(string key, string value);

        /// <summary>
        /// 根据key 和 value 获取分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        double GetValueScoreInScoreSet(string key, string value);

        /// <summary>
        /// 获取key 对应的集合的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long GetValueCount(string key);

        /// <summary>
        /// 从高到低按分数排序 获取从fromscore到toscore分数的 值的集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fromscore"></param>
        /// <param name="toscore"></param>
        /// <returns></returns>
        List<string> GetRangeFromSortedSetByHighestScore(string key, double fromscore, double toscore);

        /// <summary>
        /// 从低到高按分数排序 获取从fromscore到toscore分数的 值的集合 带分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fromscore"></param>
        /// <param name="toscore"></param>
        /// <returns></returns>
        IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string key, double fromscore, double toscore);

        /// <summary>
        /// 获取从下标fromRank 到toRank的 key对应的集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        List<string> GetRangeFromSortedSet(string key, int fromRank, int toRank);

        /// <summary>
        /// 获取从下标fromRank 到toRank的 key对应的集合  带分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string key, int fromRank, int toRank);

        /// <summary>
        /// 移除对应的一个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool RemoveItemFromSortedSet(string key, string value);

        /// <summary>
        /// 移除 从minRank下标到maxRank下标的集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="minRank"></param>
        /// <param name="maxRank"></param>
        /// <returns></returns>
        long RemoveRangeFromSortedSet(string key, int minRank, int maxRank);

        /// <summary>
        /// 删除分数fromscore 到 toscore的集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fromscore"></param>
        /// <param name="toscore"></param>
        /// <returns></returns>
        long RemoveRangeFromSortedSetByScore(string key, double fromscore, double toscore);

        /// <summary>
        /// 删除分数最大的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string PopItemWithHighestScoreFromSortedSet(string key);

        /// <summary>
        /// 删除分数最小的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string PopItemWithLowestScoreFromSortedSet(string key);

        /// <summary>
        /// 判断结合中是否包含value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SortedSetContainsItem(string key, string value);

        /// <summary>
        ///为集合中对应的value的分数加上scoreBy  返回相加之后的分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="scoreBy"></param>
        /// <returns></returns>
        double IncrementItemInSortedSet(string key, string value, double scoreBy);

        /// <summary>
        ///  获取keys多个集合的交集，并把交集添加的newkey集合中，返回交集数据的总数
        /// </summary>
        /// <param name="newkey"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        long StoreIntersectFromSortedSets(string newkey, string[] keys);

        /// <summary>
        ///  获取keys多个集合的并集，并把并集数据添加到newkey集合中，返回并集数据的总数
        /// </summary>
        /// <param name="newkey"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        long StoreUnionFromSortedSets(string newkey, string[] keys);

        /// <summary>
        /// 获取fromKey 和 keys的差集 并添加到 intoKey 值中
        /// </summary>
        /// <param name="intoKey"></param>
        /// <param name="fromKey"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        long StoreDifferencesFromSet(string intoKey, string fromKey, string[] keys);
  

    }
}
