using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using QuartZ.Web.Services;

namespace QuartZ.Web.HostServices
{
    public class SchedulerHostService : IHostedService
    {
        private QuartzManager m_quartzManager;

        public SchedulerHostService(QuartzManager quartzManager)
        {
            m_quartzManager = quartzManager;
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            m_quartzManager.Init();
            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}