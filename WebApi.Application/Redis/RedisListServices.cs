using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IRedis;

namespace WebApi.Application.Redis
{
    public class RedisListServices : RedisBaseServices, IRedisListServices
    {
        public RedisListServices() : base() { }

        public void AddItemBeforeList(string key, string value)
        {
            //RedisClient.PushItemToList(key, value);
            RedisClient.PrependItemToList(key, value);
        }

        public void AddItemsBeforeList(string key, List<string> values)
        {
            RedisClient.PrependRangeToList(key, values);
        }

        public void AddItemAfterList(string key, string value)
        {
            RedisClient.AddItemToList(key, value);
        }

        public string RemoveEndItemFromList(string key)
        {
            //RedisClient.PopItemFromList(key);
            //RedisClient.DequeueItemFromList(key);
            return RedisClient.RemoveEndFromList(key);
        }

        public string RemoveBeforeItemFromList(string key)
        {
            return RedisClient.RemoveStartFromList(key);
        }

        public void ClearList(string key)
        {
            RedisClient.RemoveAllFromList(key);
        }

        public long GetListCount(string key)
        {
            return RedisClient.GetListCount(key);
        }

        public List<string> GetListValues(string key)
        {
            return RedisClient.GetAllItemsFromList(key);
        }

        public List<string> GetRangeFromList(string key, int startingFrom, int endingAt)
        {
            return RedisClient.GetRangeFromList(key, startingFrom, endingAt);
        }

        public void TrimList(string key, int keepStartingFrom, int keepEndingAt)
        {
            RedisClient.TrimList(key, keepStartingFrom, keepEndingAt);
        }

        public string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return RedisClient.PopAndPushItemBetweenLists(fromKey, toKey);
        }
    }
}
