using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo.DLL.Impl
{
    public class GenericReflectTestMethod
    {
        private void Show1<T, W, X>(T t, W w, X x)
        {
            Console.WriteLine($"t.type={t.GetType().Name},w.type={w.GetType().Name},x.type={x.GetType().Name}");
        }

    }
    public class GenericReflectTestClass<T, TW, TX>
    {
        public void Show1(T t, TW w, TX x)
        {
            Console.WriteLine($"t.type={t.GetType().Name},w.type={w.GetType().Name},x.type={x.GetType().Name}");
        }

    }
    public class GenericReflectTestDouble<T>
    {
        public void Show1<W, X>(T t, W w, X x)
        {
            Console.WriteLine($"t.type={t.GetType().Name},w.type={w.GetType().Name},x.type={x.GetType().Name}");
        }

    }
}
