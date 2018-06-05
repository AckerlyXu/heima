using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cn.itcast.bookshop.Common
{
     public class CacheHelper
    {
        public static Object GetCacheValue(string key) {

            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            return cache[key];

        }
        public static void SetCacheValue(string key,Object value) {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache[key] = value; 

        }
        public static void RemoveCachePair(string key) {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Remove(key);

        }
        public static void SetExpires(string key,Object value, DateTime time) {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(key, value, null, time, TimeSpan.Zero);

        }
    }
}
