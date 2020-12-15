using System;
using System.Collections.Generic;
using System.Text;
using WebApi.IApplication.IServices.IRedis;

namespace WebApi.Application.Redis
{
    public class RedisZSetServices : RedisBaseServices, IRedisZSetServices
    {

        public RedisZSetServices() : base() { }

        public bool AddValue(string key, string value, double score)
        {
            return RedisClient.AddItemToSortedSet(key, value, score);
        }

        public bool AddValues(string key, List<string> values, double score)
        {
            return RedisClient.AddRangeToSortedSet(key, values, score);
        }

        public List<string> GetAllValues(string key)
        {
            return RedisClient.GetAllItemsFromSortedSet(key);
        }

        public List<string> GetAllValuesDesc(string key)
        {
            return RedisClient.GetAllItemsFromSortedSetDesc(key);
        }

        public IDictionary<string, double> GetAllWithScoresFromSortedSet(string key)
        {
            return RedisClient.GetAllWithScoresFromSortedSet(key);
        }

        public long GetValueIndexInSortedSet(string key, string value)
        {
            return RedisClient.GetItemIndexInSortedSet(key, value);
        }

        public long GetValueIndexInSortedSetDesc(string key, string value)
        {
            return RedisClient.GetItemIndexInSortedSetDesc(key, value);
        }

        public double GetValueScoreInScoreSet(string key, string value)
        {
            return RedisClient.GetItemScoreInSortedSet(key, value);
        }

        public long GetValueCount(string key)
        {
            return RedisClient.GetSortedSetCount(key);
        }

        public List<string> GetRangeFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return RedisClient.GetRangeFromSortedSetByHighestScore(key, fromscore, toscore);
        }

        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return RedisClient.GetRangeWithScoresFromSortedSetByLowestScore(key, fromscore, toscore);
        }

        public List<string> GetRangeFromSortedSet(string key, int fromRank, int toRank)
        {
            return RedisClient.GetRangeFromSortedSet(key, fromRank, toRank);
        }

        public IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return RedisClient.GetRangeWithScoresFromSortedSetDesc(key, fromRank, toRank);
        }

        public bool RemoveItemFromSortedSet(string key, string value)
        {
            return RedisClient.RemoveItemFromSortedSet(key, value);
        }

        public long RemoveRangeFromSortedSet(string key, int minRank, int maxRank)
        {
            return RedisClient.RemoveRangeFromSortedSet(key, minRank, maxRank);
        }

        public long RemoveRangeFromSortedSetByScore(string key, double fromscore, double toscore)
        {
            return RedisClient.RemoveRangeFromSortedSetByScore(key, fromscore, toscore);
        }

        public string PopItemWithHighestScoreFromSortedSet(string key)
        {
            return RedisClient.PopItemWithHighestScoreFromSortedSet(key);
        }

        public string PopItemWithLowestScoreFromSortedSet(string key)
        {
            return RedisClient.PopItemWithLowestScoreFromSortedSet(key);
        }

        public bool SortedSetContainsItem(string key, string value)
        {
            return RedisClient.SortedSetContainsItem(key, value);
        }

        public double IncrementItemInSortedSet(string key, string value, double scoreBy)
        {
            return RedisClient.IncrementItemInSortedSet(key, value, scoreBy);
        }

        public long StoreIntersectFromSortedSets(string newkey, string[] keys)
        {
            return RedisClient.StoreIntersectFromSortedSets(newkey, keys);
        }

        public long StoreUnionFromSortedSets(string newkey, string[] keys)
        {
            return RedisClient.StoreUnionFromSortedSets(newkey, keys);
        }

        public void StoreDifferencesFromSet(string intoKey, string fromKey, string[] keys)
        {
            RedisClient.StoreDifferencesFromSet(intoKey, fromKey, keys);
        }
    }
}
