using System;

namespace AutofacDemo.Services.Impl
{
    public class AccountWithParamServiceImpl
    {
        public AccountWithParamServiceImpl(string name)
        {
            Console.WriteLine($"{nameof(AccountWithParamServiceImpl)} name is {name}");
        }
    }
}
