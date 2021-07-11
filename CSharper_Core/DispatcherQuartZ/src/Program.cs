using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace DispatcherQuartZ
{
    class Program
    {
        static void Main(string[] args)
        {
            QuartzManager.Init();
            Console.Read();
        }
    }
}
