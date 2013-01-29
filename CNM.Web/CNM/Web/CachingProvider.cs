using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace CNM.Web
{
    public class CachingProvider
    {
        protected static Cache _globalCache = null;
        protected IDictionary _requestCache = null;
        protected bool _isRequestCachingEnabled = false;

        static CachingProvider()
        {
            _globalCache = System.Web.HttpRuntime.Cache;
        }

        public CachingProvider()
        {
            if(HttpContext.Current != null)
            {
                _requestCache = HttpContext.Current.Items;
                
                if(_requestCache != null)
                    _isRequestCachingEnabled = true;
            }
        }

        public virtual CacheItem<T> GetFromCache<T>(string cacheKey, PersistenceMode persistenceMode = PersistenceMode.Global)
        {
            if (persistenceMode == PersistenceMode.Global)
            {
                if (_globalCache[cacheKey] == null)
                    return new CacheItem<T>();

                return new CacheItem<T>
                {
                    WasFound = true,
                    Object = _globalCache[cacheKey].ConvertTo<T>()
                };
            }
            else if(_isRequestCachingEnabled)
            {
                if (_requestCache.Keys.OfType<string>().Any(x => x == cacheKey))
                    return new CacheItem<T> { WasFound = true, Object = _requestCache[cacheKey].ConvertTo<T>() };
                else
                    return new CacheItem<T>();
            }

            return new CacheItem<T>();
        }

        public virtual void InsertToCache(string cacheKey, object itemToCache, PersistenceMode persistenceMode = PersistenceMode.Global)
        {
            if(persistenceMode == PersistenceMode.Global)
            {
                _globalCache.Insert(cacheKey, itemToCache, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
            else if(_isRequestCachingEnabled)
            {
                if (_requestCache.Keys.OfType<string>().Any(x => x == cacheKey))
                    _requestCache[cacheKey] = itemToCache;
                else
                    _requestCache.Add(cacheKey, itemToCache);
            }
        }
    }
}
