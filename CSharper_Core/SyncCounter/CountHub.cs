using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SyncCounter.Serivces;

namespace SyncCounter
{
    public class CountHub : Hub<ICountClient>
    {
        private readonly CounterSerivce _counterSerivce;
        public CountHub(CounterSerivce couterSerivce)
        {
            _counterSerivce = couterSerivce;
        }

        //public async Task GetLatestCount()
        //{
        //    int count;
        //    do
        //    {
        //        count = _counterSerivce.GetLatestCounter();
        //        Thread.Sleep(1000);
        //        await Clients.All.SendAsync("ReceiveUpdate", count);
        //    } while (count < 10);

        //    await Clients.All.SendAsync("Finished");
        //}
        public async Task Send(string message)
        {
            Console.WriteLine($"Send {message}");
            //Clients.All.ReceiveSomeMessage(message);

            await Task.CompletedTask;
        }

        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var client = Clients.Client(connectionId);
            await client.ReceiveSomeMessage("Has Connected");
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var client = Clients.Client(connectionId);
            await client.ReceiveSomeMessage("Has DisConnected");
        }
    }
}
