using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using ReflectionDemo.DLL.Impl;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //{
            //    var assemblyName = $"{nameof(ReflectionDemo)}.{nameof(DLL)}";
            //    var typeName =
            //        $"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.{nameof(DLL.Impl.SqlDbHelper)}";
            //    var assembly = Assembly.Load(assemblyName);
            //    //var assembly = Assembly.LoadFrom($"{assemblyName}.dll");
            //    //var assembly = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.dll"));
            //    //var assembly = Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.dll"));

            //    Console.WriteLine("Types:");
            //    foreach (var type in assembly.GetTypes())
            //    {
            //        Console.WriteLine(type.Name);
            //    }

            //    Console.WriteLine("\nCalled Method:");
            //    var sqlDbHelper = assembly.GetType(typeName);
            //    dynamic sqlHelper = Activator.CreateInstance(sqlDbHelper);
            //    sqlHelper.Show();
            //}

            {
                Monitor();
            }
        }

        static void Monitor()
        {
            const int loop = 100_000_000;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < loop; i++)
            {
                var sqlHelper = new SqlDbHelper();
                sqlHelper.Get();
            }

            stopwatch.Stop();
            Console.WriteLine($"New class:{stopwatch.ElapsedMilliseconds}");

            stopwatch.Reset();
            stopwatch.Start();
            var assembly = Assembly.Load($"{nameof(ReflectionDemo)}.{nameof(DLL)}");
            var type = assembly.GetType(
                $"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.{nameof(DLL.Impl.SqlDbHelper)}");
            for (int i = 0; i < loop; i++)
            {
                dynamic sqlHelperReflection = Activator.CreateInstance(type);
                sqlHelperReflection.Get();
            }

            stopwatch.Stop();
            Console.WriteLine($"Reflection class:{stopwatch.ElapsedMilliseconds}");
        }
    }
}
