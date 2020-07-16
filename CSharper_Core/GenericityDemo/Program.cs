using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace GenericityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //var dictionaryCache = new DictionaryCache();
                //Console.WriteLine(dictionaryCache.GetCache<int>());
                //Thread.Sleep(2000);
                //Console.WriteLine(dictionaryCache.GetCache<int>());
                //Thread.Sleep(2000);
                //Console.WriteLine(dictionaryCache.GetCache<string>());
                //Thread.Sleep(2000);
                //Console.WriteLine(dictionaryCache.GetCache<int>());

                var genericIntCache = new GenericCache<int>();
                Console.WriteLine(genericIntCache.GetCache());
                Thread.Sleep(2000);
                Console.WriteLine(genericIntCache.GetCache());
                Thread.Sleep(2000);
                var genericStrCache = new GenericCache<string>();
                Console.WriteLine(genericStrCache.GetCache());
                Thread.Sleep(2000);
                Console.WriteLine(genericIntCache.GetCache());
            }


            {
                //var stopwatch1 = new Stopwatch();
                //stopwatch1.Start();
                //for (int i = 0; i < 100_000_000; i++)
                //    ShowObj(i);
                //stopwatch1.Stop();

                //var stopwatch2 = new Stopwatch();
                //stopwatch2.Start();
                //for (int i = 0; i < 100_000_000; i++)
                //    Show<int>(i);
                //stopwatch2.Stop();

                //var stopwatch3 = new Stopwatch();
                //stopwatch3.Start();
                //for (int i = 0; i < 100_000_000; i++)
                //    ShowInt(i);
                //stopwatch3.Stop();

                //Console.WriteLine($"ShowObj:{stopwatch1.ElapsedMilliseconds}");
                //Console.WriteLine($"Show Generic: {stopwatch2.ElapsedMilliseconds}");
                //Console.WriteLine($"ShowInt :{stopwatch3.ElapsedMilliseconds}");
            }

            {
                //Show<Chinese, People>();
                //Show<People, Chinese>(); // Error
            }

            {
                //Chinese chinese = (Chinese)(new People()); // Error

                //List<People> peoples = new List<Chinese>(); // Error

                //IEnumerable<People> peoples = new List<Chinese>();

                //ICustomListOut<People> customListOut = new CustomListOut<Chinese>(); // 协变
                //ICustomListIn<Chinese> customListIn = new CustomListIn<People>();

            }

            {
                //ArrayList products = new ArrayList();
                //products.AddRange(new Product[]
                //{
                //    new Product("p2"),
                //    new Product("p1"),
                //    new Product("p3")
                //});
                //products.Sort(new ProductNameComparer());

                //List<Product> products = new List<Product>
                //{
                //    new Product("p2"),
                //    new Product("p1"),
                //    new Product("p3")
                //};
                //products.Sort(new ProductNameComparerGeneric());

                //List<Product> products = new List<Product>
                //{
                //    new Product("p2"),
                //    new Product("p1"),
                //    new Product("p3")
                //};
                //products.Sort(delegate (Product x, Product y) { return x.Name.CompareTo(y.Name); });

                //foreach (var product in products)
                //{
                //    Console.WriteLine(((Product)product).Name);
                //}
            }

            Console.Read();
        }

        //static bool Compare(int x, int y)
        //{
        //    return x >= y;
        //}

        //static bool Compare(float x, float y)
        //{
        //    return x >= y;
        //}

        //static bool Compare(object x, object y)
        //{
        //    if (x is int && y is int)
        //    {
        //        return (int)x >= (int)y;
        //    }

        //    if (x is float && y is float)
        //    {
        //        return (float)x >= (float)y;
        //    }

        //    return x.GetType().Equals(y);
        //}

        //static bool Compare<T>(T x, T y)
        //    where T : IComparable<T>
        //{

        //    return x.CompareTo(y) > 0;
        //}

        static void ShowInt(int obj) { }
        static void ShowObj(object obj) { }
        static void Show<T>(T obj) { }
        static void Show<T, TU>() where T : TU
        {

        }
    }

    class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            Name = name;
        }
    }

    class ProductNameComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var productX = (Product)x;
            var productY = (Product)y;
            return productX.Name.CompareTo(productY.Name);
        }
    }
    class ProductNameComparerGeneric : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class People { }

    class Chinese : People { }

    interface ICustomListOut<out T>
    {
        T Show();
    }
    class CustomListOut<T> : ICustomListOut<T>
    {
        public T Show()
        {
            throw new NotImplementedException();
        }
    }

    interface ICustomListIn<in T>
    {
        void Show(T tIn);
    }
    class CustomListIn<T> : ICustomListIn<T>
    {
        public void Show(T tIn)
        {
            throw new NotImplementedException();
        }
    }

}
