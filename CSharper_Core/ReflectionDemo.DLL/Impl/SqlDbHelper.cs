using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo.DLL.Impl
{
    public class SqlDbHelper : IDBHelper
    {
        public void Show()
        {
            Console.WriteLine($"{nameof(Show)}");
        }

        public void Get()
        {
            //Console.WriteLine($"{nameof(Get)}");
        }
    }
}
