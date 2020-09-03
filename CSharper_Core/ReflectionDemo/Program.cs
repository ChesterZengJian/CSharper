using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using ReflectionDemo.DLL.Impl;
using ReflectionDemo.Models;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyName = $"{nameof(ReflectionDemo)}.{nameof(DLL)}";
            //var typeName =
            //    $"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.{nameof(DLL.Impl.SqlDbHelper)}";
            var assembly = Assembly.Load(assemblyName);

            {
                //var orderType = typeof(Order);

                //var obj = Activator.CreateInstance<Order>();

                //foreach (var property in typeof(Order).GetProperties())
                //{
                //    Console.WriteLine(property.PropertyType == typeof(string));
                //}

                //object[] parameters = new object[1];
                //char[] str = { 't', 'e', 's', 't' };
                //parameters[0] = str;
                //var obj = Activator.CreateInstance(typeof(string), parameters);
                //Console.WriteLine(obj);

                //var obj = Activator.CreateInstance(typeof(Order),new object[] { "Hello"});

                var obj = Activator.CreateInstance(typeof(string), new char[] {  });
            }

            {
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

                //{
                //    Monitor();
            }

            {
                //    //var reflectTest = new ReflectTest();
                //    //reflectTest.Show2("123");
                //    //reflectTest.Show3(123);
                //    //ReflectTest.Show4();

                //Type type = assembly.GetType($"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.{nameof(DLL.Impl.ReflectTest)}");
                //object objTet = Activator.CreateInstance(type);

                //try
                //{
                //    MethodInfo show1 = type.GetMethod("Show1", BindingFlags.NonPublic | BindingFlags.Instance);
                //    object result1 = show1.Invoke(objTet, new object[0]);

                //    MethodInfo show2 = type.GetMethod("Show2");
                //    object result2 = show2.Invoke(objTet, new object[0]);

                //    MethodInfo show3 = type.GetMethod("Show3", new Type[] { typeof(int) });
                //    object result3 = show3.Invoke(objTet, new object[] { 123 }); // 参数顺序跟上面一直

                //    MethodInfo show4 = type.GetMethod("Show4", BindingFlags.Static | BindingFlags.Public);
                //    object result4 = show4.Invoke(objTet, new object[0]);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

            }

            {
                //Type type = assembly.GetType($"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.{nameof(DLL.Impl.GenericReflectTestMethod)}");
                //object objTest = Activator.CreateInstance(type);
                //MethodInfo show1 = type.GetMethod("Show1");
                //MethodInfo methodInfo =
                //show1.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                //methodInfo.Invoke(objTest, new object[] { 123, "asfas", DateTime.Now });

                //Type type = assembly.GetType($"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.GenericReflectTestClass`3");
                //Type type1 = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                //object objTest = Activator.CreateInstance(type1);
                //MethodInfo show1 = type1.GetMethod("Show1");
                ////MethodInfo genericShow1 = show1.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                //show1.Invoke(objTest, new object[] { 123, "sdfa", DateTime.Now });

                //Type type = assembly.GetType(
                //$"{nameof(ReflectionDemo)}.{nameof(DLL)}.{nameof(DLL.Impl)}.GenericReflectTestDouble`1");
                //Type type1 = type.MakeGenericType(new Type[] { typeof(int) });
                //object objTest = Activator.CreateInstance(type1);
                //MethodInfo show1 = type1.GetMethod("Show1");
                //MethodInfo genericShow1 = show1.MakeGenericMethod(new Type[] { typeof(string), typeof(DateTime) });
                //genericShow1.Invoke(objTest, new object[] { 123, "asfa", DateTime.Now });

            }

            {
                //People people = new People
                //{
                //    Id = "1",
                //    Name = "P1",
                //    Sex = true
                //};

                //Type peopleType = typeof(People);
                //object objPeople = Activator.CreateInstance(peopleType);
                //foreach (var propertyInfo in peopleType.GetProperties())
                //{
                //    if (propertyInfo.Name == "Id")
                //    {
                //        propertyInfo.SetValue(objPeople, "123");
                //    }
                //    else if (propertyInfo.Name == "Name")
                //    {
                //        propertyInfo.SetValue(objPeople, "My Name");
                //    }
                //}

                //foreach (var propertyInfo in peopleType.GetProperties())
                //{
                //    Console.WriteLine($"{propertyInfo.Name}={propertyInfo.GetValue(objPeople)}");
                //}
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

    class People
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
