using System;

namespace Polly.Client.Common
{
    public class CommOnClass
    {
        public virtual void MethodInterceptor()
        {
            Console.WriteLine("MethodInterceptor");
        }

        public void MethodNoInterceptor()
        {
            Console.WriteLine("MethodNoInterceptor");
        }
    }
}