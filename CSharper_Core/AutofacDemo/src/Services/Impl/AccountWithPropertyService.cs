using System;
using AutofacDemo.Models;

namespace AutofacDemo.Services.Impl
{
    public class AccountWithPropertyService : IAccountService
    {
        public User User { get; set; }

        public AccountWithPropertyService()
        {
        }

        public void Print()
        {
            Console.WriteLine(User.Name);
        }
    }
}
