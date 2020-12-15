using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IRedis;

namespace WebApi.Application.Redis
{
    public class RedisHashServices : RedisBaseServices, IRedisHashServices
    {
        public RedisHashServices() : base() { }

        public bool SetValueInHash(string hashId, string key, string value)
        {
            return RedisClient.SetEntryInHash(hashId, key, value);
        }

        public bool SetValueInHashIfNotExists(string hashId, string key, string value)
        {
            return RedisClient.SetEntryInHashIfNotExists(hashId, key, value);
        }

        public void SetDictionaryInHash(string hashId, Dictionary<string, string> keyValuePairs)
        {
            RedisClient.SetRangeInHash(hashId, keyValuePairs);
        }

        public string GetValuesFromHash(string hashId, string key)
        {
            return RedisClient.GetValueFromHash(hashId, key);
        }

        public Dictionary<string, string> GetDictionaryFromHash(string hashId)
        {
            return RedisClient.GetAllEntriesFromHash(hashId);
        }

        public long GetCountFromHash(string hashId)
        {
            return RedisClient.GetHashCount(hashId);
        }

        public List<string> GetListValueFromHash(string hashId)
        {
            return RedisClient.GetHashValues(hashId);
        }

        public List<string> GetListKeyFromHash(string hashId)
        {
            return RedisClient.GetHashKeys(hashId);
        }

        public List<string> GetValuesFromHash(string hashId, params string[] keys)
        {
            return RedisClient.GetValuesFromHash(hashId, keys);
        }

        public bool HashContainsEntry(string hashId, string key)
        {
            return RedisClient.HashContainsEntry(hashId, key);
        }

        public IEnumerable<KeyValuePair<string, string>> ScanAllHashEntries(string hashId)
        {
            return RedisClient.ScanAllHashEntries(hashId);
        }

        public bool RemoveValueFromHash(string hashId, string key)
        {
            return RedisClient.RemoveEntryFromHash(hashId, key);
        }

        public void StoreAsHash<T>(T entity)
        {
            RedisClient.StoreAsHash<T>(entity);
        }

        public T GetFromHash<T>(object id)
        {
            return RedisClient.GetFromHash<T>(id);
        }

        public long IncrementValueInHash(string hashId, string key, int incrementBy)
        {
            return RedisClient.IncrementValueInHash(hashId, key, incrementBy);
        }
    }
}
