using System;
using Quartz;
using Quartz.Impl;

namespace QuartZ.Web.Services
{
    public class QuartzManager
    {
        private readonly IServiceProvider _serviceProvider;

        public QuartzManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async void Init()
        {
            try
            {
                var factory = new StdSchedulerFactory();
                var scheduler = await factory.GetScheduler();
                scheduler.JobFactory = new SendMessageJobFactory(_serviceProvider);

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

                var trigger2 = TriggerBuilder.Create()
                    .WithIdentity("t2", "g1")
                    .WithSimpleSchedule(builder =>
                    {
                        builder.WithIntervalInSeconds(3)
                            .WithMisfireHandlingInstructionFireNow()
                            .WithRepeatCount(3);
                    })
                    .WithDescription("A test of quartz 2")
                    //.WithCronSchedule("1/2 * * * * ?")
                    .Build();
                trigger2.JobDataMap.Add("studentTrigger", "good student trigger2");

                var job2 = JobBuilder.Create<SendMessageJob>().Build();
                job2.JobDataMap.Add("student", "good student2");
                job2.JobDataMap.Add("count", 0);

                await scheduler.ScheduleJob(job, trigger);
                await scheduler.ScheduleJob(job2, trigger2);
                await scheduler.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}