using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService01.Common
{
public static class ConsulHelper
{
    public static void ConsulRegister(this IConfiguration configuration)
    {
        var consul = new ConsulClient(c =>
        {
            c.Address = new Uri("http://localhost:8500/");
            c.Datacenter = "dc1";
        });
        var ip = configuration["ip"];
        var port = int.Parse(configuration["port"]);
        var weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);

        consul.Agent.ServiceRegister(new AgentServiceRegistration()
        {
            ID = $"service{Guid.NewGuid()}",
            Name = "ConsulServiceDemo",
            Address = ip,
            Port = port,
            Tags = new string[] { weight.ToString() },
            Check = new AgentServiceCheck()
            {
                Interval = TimeSpan.FromSeconds(10),                            // 检查间隔
                HTTP = $"http://{ip}:{port}/api/health",
                Timeout = TimeSpan.FromSeconds(4),                              // 超时
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(60)       // 失败多久移除，最小60s
            }
        });
    }
}
}
