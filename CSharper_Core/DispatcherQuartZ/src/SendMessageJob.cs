using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace DispatcherQuartZ
{
    [PersistJobDataAfterExecution]
    public class SendMessageJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("================================================");

                Console.WriteLine($"Thread Id = {Thread.CurrentThread.ManagedThreadId:00}," +
                                  $"current time is {DateTime.Now:yyyy-MM-dd hh:mm:ss}");
                Console.WriteLine($"student-{context.JobDetail.JobDataMap.GetString("student")}");

                Console.WriteLine($"trigger student-{context.Trigger.JobDataMap.GetString("studentTrigger")}");

                Console.WriteLine($"merger student-{context.MergedJobDataMap.GetString("student")}");
                Console.WriteLine($"merger student-{context.MergedJobDataMap.GetString("studentTrigger")}");

                context.JobDetail.JobDataMap.Put("count", context.JobDetail.JobDataMap.GetInt("count") + 1);
                Console.WriteLine($"count-{context.JobDetail.JobDataMap.GetIntValue("count")}");

                Console.WriteLine("================================================");
            });
        }
    }
}