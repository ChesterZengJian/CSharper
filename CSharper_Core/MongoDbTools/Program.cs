using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MongoDbTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyName =
                @"F:\My_GitHubProject\CSharper\CSharper_Core\MongoDbDemo\bin\Debug\netcoreapp3.1\MongoDbDemo.dll";
            var assembly = Assembly.LoadFrom(assemblyName);
            var modelTypes = assembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains(".Models"));

            foreach (var type in modelTypes)
            {
                Console.WriteLine($"Type name: {type.Name}\nAssemblyQualifiedName: {type.AssemblyQualifiedName}\nModule: {type.Module}\nNamespace: {type.Namespace}");
                PrintModelInfo(type);
                Console.WriteLine();
            }

        }

        private static void PrintModelInfo(Type type)
        {
            var propertyInfos = type.GetProperties();
            IReadOnlyDictionary<Type, string> mongoDbType = new Dictionary<Type, string>()
            {
                {typeof(string), "String"},
                {typeof(int), "Integer"},
                {typeof(bool), "Boolean"},
                {typeof(double), "Double"},
                //{typeof(IList), "Array"},
                {typeof(DateTime), "Timestamp"},
                {typeof(object), "Object"},
            };

            foreach (var propertyInfo in propertyInfos)
            {
                if (typeof(IList) == propertyInfo.PropertyType)
                {
                    Console.WriteLine();
                }
                //Console.WriteLine($"The {propertyInfo.Name} of {type.Name} is {mongoDbType[propertyInfo.PropertyType]}");
            }

        }
    }
}
