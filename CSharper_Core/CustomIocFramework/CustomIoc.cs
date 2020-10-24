using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using CustomIocFramework.CommonEnums;

namespace CustomIocFramework
{
    public class CustomIoc
    {
        #region No Lifetime

        //private static readonly Dictionary<string, Type> _containerDictionary = new Dictionary<string, Type>();

        //public void Register<TSource, TDistinct>(CustomLifetime lifetime = CustomLifetime.Transient)
        //{
        //    _containerDictionary.Add(typeof(TSource).FullName ?? throw new ArgumentException($"{typeof(TSource)} invalidate"), typeof(TDistinct));
        //}

        //public T Resolve<T>()
        //{
        //    var implementType = _containerDictionary[typeof(T).FullName ?? throw new ArgumentException($"{typeof(T)} invalidate")];
        //    return (T)InstanceObj(implementType);
        //}

        //public object InstanceObj(Type type)
        //{
        //    var constructorInfos = type.GetConstructors();
        //    var ctorParamInstances = new List<object>();
        //    var constructorInfo = constructorInfos.OrderByDescending(ctor => ctor.GetParameters().Length)
        //        .First();

        //    var ctorParams = constructorInfo.GetParameters();
        //    foreach (var ctorParam in ctorParams)
        //    {
        //        var ctorParamType = ctorParam.ParameterType;
        //        var ctorParamImplementType = _containerDictionary[ctorParamType.FullName ?? throw new ArgumentException($"{ctorParamType} invalidate")];
        //        ctorParamInstances.Add(InstanceObj(ctorParamImplementType));
        //    }

        //    return Activator.CreateInstance(type, ctorParamInstances.ToArray());
        //}

        #endregion

        #region Lifetime

        private Dictionary<string, ContainerInfo> _customContainer = new Dictionary<string, ContainerInfo>();
        private Dictionary<Type, object> _singleton = new Dictionary<Type, object>();

        public void Register<TSource, TDestination>(CustomLifetime lifetime = CustomLifetime.Transient)
        {
            _customContainer.Add(typeof(TSource).FullName ?? throw new ArgumentException($"{typeof(TSource)} invalidate"), new ContainerInfo
            {
                ObjectType = typeof(TDestination),
                Lifetime = lifetime
            });
        }

        public T Resolve<T>()
        {
            var containerInfo =
                _customContainer[typeof(T).FullName ?? throw new ArgumentException($"{typeof(T)} invalidate")];
            return (T)GetInstanceFactory(containerInfo);
        }
        private object GetInstanceFactory(ContainerInfo containerInfo)
        {
            switch (containerInfo.Lifetime)
            {
                case CustomLifetime.Transient:
                    return ObjectInstance(containerInfo);
                case CustomLifetime.Singleton:
                    if (!_singleton.ContainsKey(containerInfo.ObjectType))
                    {
                        _singleton[containerInfo.ObjectType] = ObjectInstance(containerInfo);
                    }

                    return _singleton[containerInfo.ObjectType];
                case CustomLifetime.SingletonPerThread:
                    throw new NotImplementedException();
                default:
                    return default;
            }
        }

        private object ObjectInstance(ContainerInfo containerInfo)
        {
            var ctorParams = new List<object>();

            foreach (var ctorParam in containerInfo.ObjectType.GetConstructors().OrderByDescending(ctor => ctor.GetParameters().Length).First().GetParameters())
            {
                var ctorParamContainerInfo = new ContainerInfo
                {
                    ObjectType =
                        _customContainer[
                            ctorParam.ParameterType.FullName ??
                            throw new ArgumentException($"{ctorParam.ParameterType} invalidate")].ObjectType,
                    Lifetime = _customContainer[
                        ctorParam.ParameterType.FullName ??
                        throw new ArgumentException($"{ctorParam.ParameterType} invalidate")].Lifetime
                };

                ctorParams.Add(GetInstanceFactory(ctorParamContainerInfo));
            }
            var instance = Activator.CreateInstance(containerInfo.ObjectType, ctorParams.ToArray());

            return instance;
        }

        public class ContainerInfo
        {
            public Type ObjectType { get; set; }

            public CustomLifetime Lifetime { get; set; }
        }

        #endregion

    }
}