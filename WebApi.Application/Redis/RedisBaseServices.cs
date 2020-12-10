using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IResource;
using WebApi.IApplication.IServices.Redis;
using ServiceStack.Redis;

namespace WebApi.Application.Redis
{
    public class RedisBaseServices : IBaseRedisServices
    {

        protected IRedisClient RedisClient { private set; get; }

        /// <summary>
        /// 创建Redis的实例
        /// </summary>
        protected void CreateRedisClient(int defaultDb = 1)
        {
            List<string> redisAdresses = new List<string>() { "127.0.0.1" };
            PooledRedisClientManager pooledRedisClientManager = new PooledRedisClientManager(redisAdresses, redisAdresses, new RedisClientManagerConfig
            {
                DefaultDb = defaultDb,
                AutoStart = true,
                MaxReadPoolSize = 5,
                MaxWritePoolSize = 5
            });

            RedisClient = pooledRedisClientManager.GetClient();
        }

        /// <summary>
        /// 返回redis实例
        /// </summary>
        /// <returns></returns>
        protected IRedisClient GetRedisClient()
        {
            if (RedisClient == null)
            {
                CreateRedisClient();
            }

            return RedisClient;
        }

        /// <summary>
        /// 获取所有的key
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKeys()
        {
            return RedisClient.GetAllKeys();
        }

        /// <summary>
        /// 移除对应的key
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveKey(params string[] keys)
        {
            RedisClient.RemoveAll(keys);
        }

        /// <summary>
        /// 重新命名Key
        /// </summary>
        /// <param name="oldKey"></param>
        /// <param name="newKey"></param>
        public void RenameKey(string oldKey, string newKey)
        {
            RedisClient.RenameKey(oldKey, newKey);
        }
    }
}
