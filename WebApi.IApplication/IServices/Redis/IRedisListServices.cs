using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.IApplication.IServices.Redis
{
    /// <summary>
    /// list  是一个双向列表 
    /// </summary>
    public interface IRedisListServices
    {

        /// <summary>
        /// 向数组最前面添加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddItemBeforeList(string key, string value);

        /// <summary>
        /// 向数组最前面添加多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        void AddItemsBeforeList(string key, List<string> values);
  
        /// <summary>
        /// 向数组最后面添加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddItemAfterList(string key, string value);

        /// <summary>
        /// 移除数组最后面的一个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string RemoveEndItemFromList(string key);

        /// <summary>
        /// 移除数组最前的一个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string RemoveBeforeItemFromList(string key);
 
        /// <summary>
        /// 清除数组
        /// </summary>
        /// <param name="key"></param>
        void ClearList(string key);
 
        /// <summary>
        /// 获取数组的集合的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long GetListCount(string key);
  
        /// <summary>
        /// 获取数组存放的所有的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<string> GetListValues(string key);

        /// <summary>
        /// 从对应集合出获取数组
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startingFrom"></param>
        /// <param name="endingAt"></param>
        /// <returns></returns>
        List<string> GetRangeFromList(string key, int startingFrom, int endingAt);

        /// <summary>
        /// 截取数组 只保留对应索引的集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keepStartingFrom"></param>
        /// <param name="keepEndingAt"></param>
        void TrimList(string key, int keepStartingFrom, int keepEndingAt);

        /// <summary>
        /// 从fromKey 对应的集合移除最后一个值 添加到toKey对应的集合的前面
        /// </summary>
        /// <param name="fromKey"></param>
        /// <param name="toKey"></param>
        /// <returns></returns>
        string PopAndPushItemBetweenLists(string fromKey, string toKey);

    }
}
