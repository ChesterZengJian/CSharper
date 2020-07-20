using System;
using System.Security.Cryptography.X509Certificates;

namespace DelegateDemo.src.Delegates
{
    public class CustomDelegate
    {
        public delegate void NoReturnNoParam();

        public delegate int NoReturnWithParam(int x, int y);

        public delegate int Del(int x);

        public void Show()
        {
            {
                //NoReturnNoParam noReturnNoParam = new NoReturnNoParam(NoReturnNoParamMethod);
                //MethodCallback(1, 3, new NoReturnWithParam(NoReturnWithParamMethod));
                //noReturnNoParam();
            }

            {
                Del d1 = Method1;
                Del d2 = Method2;
                Del d3 = Method3;

                Del allMethod = d1 + d2;
                allMethod += d3;
                Console.WriteLine(allMethod(1));
            }
        }

        public void NoReturnNoParamMethod()
        {
            Console.WriteLine("NoReturnNoParam");
        }

        public int NoReturnWithParamMethod(int x, int y)
        {
            Console.WriteLine($"x+y={x + y}");
            return x + y;
        }

        public int Method1(int x)
        {
            return x + 1;
        }

        public int Method2(int x)
        {
            return x + 2;
        }

        public int Method3(int x)
        {
            return x + 3;
        }

        public int MethodCallback(int x, int y, NoReturnWithParam callback)
        {
            return callback(x, y);
        }
    }
}