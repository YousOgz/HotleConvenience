using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;

namespace HotleConvenience.Lib.Cache
{
    public class CustomMemoryCache : ICache
    {
        private IMemoryCache _memoryCache;
        public CustomMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddOrUpdate<T>(string key, T value, int time=7200)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _memoryCache.Set<T>(key, value, TimeSpan.FromSeconds(time));
        }

        public void AddOrUpdate<T>(string key, T value)
        {
            AddOrUpdate<T>(key, value, 7200);
        }

        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (_memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }
            return default(T);
        }

        public bool HasKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _memoryCache.TryGetValue(key, out var value);
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            _memoryCache.Remove(key);
        }
    }
}
