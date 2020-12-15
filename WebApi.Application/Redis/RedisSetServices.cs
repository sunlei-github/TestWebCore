using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IRedis;

namespace WebApi.Application.Redis
{
    public class RedisSetServices : RedisBaseServices, IRedisSetServices
    {

        public RedisSetServices() : base() { }

        public void AddValue(string key, string value)
        {
            RedisClient.AddItemToSet(key, value);
        }

        public void AddValues(string key, List<string> values)
        {
            RedisClient.AddRangeToSet(key, values);
        }

        public string GetRandomValue(string key)
        {
            return RedisClient.GetRandomItemFromSet(key);
        }

        public HashSet<string> GetAllValues(string key)
        {
            return RedisClient.GetAllItemsFromSet(key);
        }

        public long GetValueCount(string key)
        {
            return RedisClient.GetSetCount(key);
        }

        public void RemoveValue(string key, string value)
        {
            RedisClient.RemoveItemFromSet(key, value);
        }

        public void MoveBetweenSets(string fromKey, string toKey, string value)
        {
            RedisClient.MoveBetweenSets(fromKey, toKey, value);
        }

        public HashSet<string> GetUnionFromSets(params string[] keys)
        {
            return RedisClient.GetUnionFromSets(keys);
        }

        public HashSet<string> GetIntersectFromSets(params string[] keys)
        {
            return RedisClient.GetIntersectFromSets(keys);
        }

        public HashSet<string> GetDifferencesFromSet(string fromKey, params string[] keys)
        {
            return RedisClient.GetDifferencesFromSet(fromKey, keys);
        }

        public void StoreUnionFromSets(string intoKey, params string[] keys)
        {
            RedisClient.StoreUnionFromSets(intoKey, keys);
        }
        public void StoreDifferencesFromSet(string fromKey, string intoKey, params string[] keys)
        {
            RedisClient.StoreDifferencesFromSet(fromKey, intoKey, keys);
        }

        public void StoreIntersectFromSets(string intoKey, params string[] keys)
        {
            RedisClient.StoreIntersectFromSets(intoKey, keys);
        }
    }
}
