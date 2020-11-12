using Quartz;
using Quartz.Impl;

namespace DispatcherQuartZ
{
    public class QuartzManager
    {
        public static async void Init()
        {
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();

            scheduler.ListenerManager.AddJobListener(new CustomJobListener());

            var job = JobBuilder.Create<SendMessageJob>().Build();
            job.JobDataMap.Add("student", "good student");
            job.JobDataMap.Add("count", 0);

            var trigger = TriggerBuilder.Create()
                .WithIdentity("t1", "g1")
                .WithSimpleSchedule(builder =>
                {
                    builder.WithIntervalInSeconds(3)
                        .WithMisfireHandlingInstructionFireNow()
                        .WithRepeatCount(3);
                })
                .WithDescription("A test of quartz")
                //.WithCronSchedule("1/2 * * * * ?")
                .Build();
            trigger.JobDataMap.Add("studentTrigger", "good student trigger");

            await scheduler.ScheduleJob(job, trigger);
            await scheduler.Start();
        }
    }
}