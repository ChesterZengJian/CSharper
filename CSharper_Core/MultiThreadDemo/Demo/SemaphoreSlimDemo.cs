using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadDemo
{
    class SemaphoreSlimDemo
    {
        private static SemaphoreSlim m_semaphoreSlim = new SemaphoreSlim(4);

        public static async void AccessDb(string name, int seconds)
        {
            Console.WriteLine($"{name} wait the DB");
            m_semaphoreSlim.Wait();
            Console.WriteLine($"{name} has access DB");
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{name} has completed");
            m_semaphoreSlim.Release();
        }
    }
}
