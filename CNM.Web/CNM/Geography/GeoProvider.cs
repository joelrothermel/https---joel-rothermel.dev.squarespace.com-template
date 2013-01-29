using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Geography.Repositories;
using CNM.Models;
using CNM.Web;

namespace CNM.Geography
{
    public class GeoProvider
    {
        protected CachingProvider _cachingProvider = null;
        protected GeoRepository _repository = null;

        public GeoProvider(CachingProvider cachingProvider, GeoRepository repository)
        {
            _cachingProvider = cachingProvider;
            _repository = repository;
        }

        public IEnumerable<string> GetStates()
        {
            var cacheKey = "GeoStates";

            var cacheItem = _cachingProvider.GetFromCache<IEnumerable<string>>(cacheKey, PersistenceMode.Global);

            if (cacheItem.WasFound)
                return cacheItem.Object;

            var states = _repository.GetStates().Distinct().ToList();

            _cachingProvider.InsertToCache(cacheKey, states);

            return states;
        }

        public IEnumerable<string> GetCitiesFor(string stateName)
        {
            var cacheKey = "GeoCities" + stateName;

            var cacheItem = _cachingProvider.GetFromCache<IEnumerable<string>>(cacheKey, PersistenceMode.Global);

            if (cacheItem.WasFound)
                return cacheItem.Object;

            var cities = _repository.GetCitiesFor(stateName).Distinct().ToList();

            _cachingProvider.InsertToCache(cacheKey, cities);

            return cities;
        }
    }
}
