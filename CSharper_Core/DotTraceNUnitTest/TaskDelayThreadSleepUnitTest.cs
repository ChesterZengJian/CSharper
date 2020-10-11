using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DotTraceNUnitTest
{
    public class TaskDelayThreadSleepUnitTest
    {
        [Test]
        public Task TaskDelayUnitTest()
        {
            return Task.Delay(TimeSpan.FromSeconds(3));
        }

        [Test]
        public Task ThreadSleepUnitTest()
        {
            return Task.Run(() => Thread.Sleep(TimeSpan.FromSeconds(3)));
        }
    }
}