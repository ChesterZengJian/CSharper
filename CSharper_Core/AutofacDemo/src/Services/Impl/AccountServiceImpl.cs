using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacDemo.Services.Impl
{
    public class AccountServiceImpl:IAccountService
    {
        public AccountServiceImpl()
        {
            Console.WriteLine($"{nameof(AccountServiceImpl)}");
        }

        public void Print()
        {
            Console.WriteLine(nameof(AccountServiceImpl));
        }
    }
}
