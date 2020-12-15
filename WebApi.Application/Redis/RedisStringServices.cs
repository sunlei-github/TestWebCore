using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IRedis;

namespace WebApi.Application.Redis
{
    public class RedisStringServices : RedisBaseServices, IRedisStringServices
    {
        public RedisStringServices() : base() { }

        public void SetValue(string key, string value)
        {
            RedisClient.SetValue(key, value);
        }

        public void SetAllValue(IEnumerable<string> keys, IEnumerable<string> values)
        {
            RedisClient.SetAll(keys, values);
        }

        public bool SetValueIfExists(string key, string value)
        {
            return RedisClient.SetValueIfExists(key, value);
        }

        public bool SetValueIfNotExists(string key, string value)
        {
            return RedisClient.SetValueIfNotExists(key, value);
        }

        public bool Replace<T>(string key, T newValue)
        {
            return RedisClient.Replace<T>(key, newValue);
        }

        public List<string> GetAllKeys()
        {
            return RedisClient.GetAllKeys();
        }

        public void RemoveKey(params string[] keys)
        {
            RedisClient.RemoveAll(keys);
        }

        public void RenameKey(string oldKey, string newKey)
        {
            RedisClient.RenameKey(oldKey, newKey);
        }

        public bool Set<T>(string key, T value, DateTime expiredTime)
        {
            return RedisClient.Set(key, value, expiredTime);
        }

        public void SetAll<T>(Dictionary<string, string> dictionary)
        {
            RedisClient.SetAll(dictionary);
        }

        public long Append(string key, string value)
        {
            return RedisClient.AppendToValue(key, value);
        }

        public long IncrementValue(string key)
        {
            return RedisClient.IncrementValue(key);
        }

        public long IncrementValueBy(string key, int count)
        {
            return RedisClient.IncrementValueBy(key, count);
        }

        public long DecrementValue(string key)
        {
            return RedisClient.DecrementValue(key);
        }

        public long DecrementValueBy(string key, int count)
        {
            return RedisClient.DecrementValueBy(key, count);
        }
    }
}
