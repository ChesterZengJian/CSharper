using System;
using System.Threading;
using System.Threading.Tasks;
using EFCoreDemo.Data;
using EFCoreDemo.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreDemo.HostedServices
{
    public class SchoolContextHostedService : IHostedService
    {
        private readonly IServiceProvider m_serviceProvide;

        public SchoolContextHostedService(IServiceProvider mServiceProvide)
        {
            m_serviceProvide = mServiceProvide;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var m_schoolContext = m_serviceProvide.CreateScope().ServiceProvider.GetRequiredService<SchoolContext>();
            m_schoolContext.Database.EnsureDeleted();
            m_schoolContext.Database.EnsureCreated();
            m_schoolContext.Departments.Add(new Department() { Id = 1 });
            m_schoolContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}