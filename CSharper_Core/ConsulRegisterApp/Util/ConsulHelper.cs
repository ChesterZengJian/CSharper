using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Configuration;

namespace ConsulRegisterApp.Util
{
    public static class ConsulHelper
    {
        public static void ConsulRegister(this IConfiguration configuration)
        {
            var consul = new ConsulClient(c =>
            {
                c.Address = new Uri("http://chestervm-126.com:8500/");
                c.Datacenter = "dc1";
            });
            var ip = configuration["IP"];
            var port = int.Parse(configuration["Port"]);
            var weight = string.IsNullOrWhiteSpace(configuration["Weight"]) ? 1
                : int.Parse(configuration["weight"]);

            consul.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = $"service-{Guid.NewGuid()}",
                Name = "ConsulServiceDemo",
                Address = ip,
                Port = port,
                Tags = new string[] { weight.ToString() },
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(10),
                    HTTP = $"http://192.168.3.29:5000/api/health",
                    Timeout = TimeSpan.FromSeconds(4),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(60)
                }
            });
        }
    }
}
