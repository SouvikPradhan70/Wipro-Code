using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeManagement.Filters
{
    public class ProductCacheResultFilter : IResultFilter
    {
        private readonly IMemoryCache _cache;

        public ProductCacheResultFilter(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var cacheKey = context.HttpContext.Request.Path;

            if (_cache.TryGetValue(cacheKey, out IActionResult cachedResult))
            {
                Console.WriteLine($"✅ Cache HIT for {cacheKey}");
                context.Result = cachedResult;
            }
            else
            {
                Console.WriteLine($"❌ Cache MISS for {cacheKey}");
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var cacheKey = context.HttpContext.Request.Path;
            _cache.Set(cacheKey, context.Result, TimeSpan.FromSeconds(30));

            Console.WriteLine($"💾 Stored result in cache for {cacheKey}");

            // Keep track of all cache keys
            if (!_cache.TryGetValue("AllKeys", out List<string> keys))
                keys = new List<string>();

            if (!keys.Contains(cacheKey))
                keys.Add(cacheKey);

            _cache.Set("AllKeys", keys);
        }
    }
}
