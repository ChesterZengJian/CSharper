using DelegateDemo.src.Delegates;
using System;
using DelegateDemo.Extensions;
using DelegateDemo.Models;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //var customDelegate = new CustomDelegate();
                //customDelegate.Show();
            }

            {
                //var delegateMethod = new CustomDelegateExtension();
                //delegateMethod.Show();
            }

            {
                EventStandard.Show();

            }
        }
    }
}
