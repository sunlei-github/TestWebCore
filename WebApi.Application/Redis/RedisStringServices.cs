using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.Redis;

namespace WebApi.Application.Redis
{
    public class RedisStringServices : RedisBaseServices, IRedisStringServices
    {
        public RedisStringServices()
        {
            CreateRedisClient();
        }

        public void Test()
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                keys.Add($"key{i}");
                values.Add(Guid.NewGuid().ToString());
            }

            RedisClient.SetValue("key1", "value1");
            RedisClient.SetAll(keys, values);
            RedisClient.SetValueIfExists("key1", "value aaa");
            RedisClient.SetValueIfNotExists("key2", "value bbbb");
            RedisClient.Replace("key2", "value cccc key2");
            var key1s = RedisClient.GetAllKeys();
            RedisClient.RemoveAll(keys);
        }

        public void SetValue(string key,string value)
        {
            RedisClient.SetValue(key, value);
        }

        public void SetAllValue(IEnumerable<string> keys, IEnumerable<string> values)
        {
            RedisClient.SetAll(keys, values);
        }

        public bool SetValueIfExists(string key,string value)
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
    }
}
