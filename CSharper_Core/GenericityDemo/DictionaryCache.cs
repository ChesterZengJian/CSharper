using System;
using System.Collections.Generic;
using System.Text;

namespace GenericityDemo
{
    class DictionaryCache
    {
        private static Dictionary<Type, string> _dictionaryCache;

        static DictionaryCache()
        {
            _dictionaryCache = new Dictionary<Type, string>();
        }


        public string GetCache<T>()
        {
            var type = typeof(T);
            if (!_dictionaryCache.ContainsKey(type))
            {
                _dictionaryCache.Add(type, $"{type.FullName}_{DateTime.Now.Ticks}");
            }

            return _dictionaryCache[type];
        }
    }
}
