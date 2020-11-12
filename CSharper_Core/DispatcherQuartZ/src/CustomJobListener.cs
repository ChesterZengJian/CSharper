using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace DispatcherQuartZ
{
    public class CustomJobListener : IJobListener
    {
        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Run(() =>
            {
                Console.WriteLine("=====JobToBeExecuted=====");
            }, cancellationToken);
        }

        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Run(() =>
            {
                Console.WriteLine("=====JobExecutionVetoed=====");
            }, cancellationToken);
        }

        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException,
            CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Run(() =>
            {
                Console.WriteLine("=====JobWasExecuted=====");
            }, cancellationToken);
        }

        public string Name => "CustomJobListener";
    }
}