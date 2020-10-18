using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomIocFramework
{
    public class CustomIoc
    {
        private static readonly Dictionary<string, Type> _containerDictionary = new Dictionary<string, Type>();

        public void Register<TSource, TDistinct>()
        {
            _containerDictionary.Add(typeof(TSource).FullName ?? throw new ArgumentException($"{typeof(TSource)} invalidate"), typeof(TDistinct));
        }

        public T Resolve<T>()
        {
            var implementType = _containerDictionary[typeof(T).FullName ?? throw new ArgumentException($"{typeof(T)} invalidate")];
            return (T)InstanceObj(implementType);
        }

        public object InstanceObj(Type type)
        {
            var constructorInfos = type.GetConstructors();
            var ctorParamInstances = new List<object>();
            if (constructorInfos.Length > 0)
            {
                var constructorInfo = constructorInfos.OrderByDescending(ctor => ctor.GetParameters().Length)
                    .First();

                var ctorParams = constructorInfo.GetParameters();
                foreach (var ctorParam in ctorParams)
                {
                    var ctorParamType = ctorParam.ParameterType;
                    var ctorParamImplementType = _containerDictionary[ctorParamType.FullName ?? throw new ArgumentException($"{ctorParamType} invalidate")];
                    ctorParamInstances.Add(InstanceObj(ctorParamImplementType));
                }
            }

            return Activator.CreateInstance(type, ctorParamInstances.ToArray());
        }
    }
}