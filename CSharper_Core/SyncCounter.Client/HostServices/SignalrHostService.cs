using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;

namespace SyncCounter.Client.HostServices
{
    public class SignalRHostService : BackgroundService
    {
        private HubConnection connection;

        public SignalRHostService()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(" http://localhost:5004/api/counthub")
                .Build();

            connection.On<string>("ReceiveSomeMessage", async msg =>
             {
                 Console.WriteLine($"Receive msg: {msg}");

                 await connection.InvokeAsync("Send", "hhhhello");
             });


        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await connection.StartAsync(stoppingToken);
                Console.WriteLine("Connect successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex}");
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start bg work");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop bg work");
            return base.StopAsync(cancellationToken);
        }

        public async Task SendToServer()
        {
            await connection.InvokeAsync("Send", "hhhhello");
        }
    }
}