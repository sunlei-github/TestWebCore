using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IResource;
using WebApi.IApplication.IServices.Redis;
using ServiceStack.Redis;

namespace WebApi.Application.Redis
{
    public class RedisBaseServices 
    {
        protected IRedisClient RedisClient { private set; get; }

        public RedisBaseServices()
        {
            CreateRedisClient();
        }

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


    }
}
