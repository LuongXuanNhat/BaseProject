using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Common
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> Get<T>(string key)
        {
            return await Task.FromResult(_memoryCache.Get<T>(key));
        }

        public async Task Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            var options = new MemoryCacheEntryOptions();
            if (expiry.HasValue)
            {
                options.SetAbsoluteExpiration(DateTimeOffset.Now.Add(expiry.Value));
            }
            await Task.FromResult(_memoryCache.Set(key, value, options));
        }

        public async Task Remove(string key)
        {
            _memoryCache.Remove(key);
            await Task.CompletedTask;
        }
    }
}
