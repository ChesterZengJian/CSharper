using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ServiceModel;
using SOA.WCF.Service;

namespace SOA.WCF.Project
{
    public class ServiceInit
    {
        public static void Process()
        {
            var hosts = new List<ServiceHost>
            {
                new ServiceHost(typeof(MathService))
            };

            foreach (var host in hosts)
            {
                host.Opening += (s, e) => Console.Write($"{host.GetType().Name} Opened");
                // An unauthorized error may occur, open vs with administrator
                host.Open();
            }

            Console.WriteLine("Input any char to continue");
            Console.Read();

            foreach (var host in hosts)
            {
                host.Close();
            }

            Console.WriteLine("Input any char to continue");
            Console.Read();
        }
    }
}