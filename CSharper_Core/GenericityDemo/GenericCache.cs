using System;

namespace GenericityDemo
{
public class GenericCache<T>
{
    private static readonly string _cache;
    static GenericCache()
    {
        _cache = $"{typeof(T).FullName}_{DateTime.Now.Ticks}";
    }

    public string GetCache()
    {
        return _cache;
    }
}
}