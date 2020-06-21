using System;

namespace AutofacDemo.Services.Impl
{
    public class DiffAccountServiceImpl : IAccountService, IDiffAccountService
    {
        public DiffAccountServiceImpl()
        {
            Console.WriteLine($"{nameof(DiffAccountServiceImpl)}");
        }

        public void Print()
        {
            Console.WriteLine(nameof(DiffAccountServiceImpl));
        }
    }
}
