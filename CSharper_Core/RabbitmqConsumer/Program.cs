using RabbitMQ.Client;
using System;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitmqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory
            {
                UserName = "chester",
                Password = "123456",
                HostName = "192.168.3.125"
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            var eventConsumer = new EventingBasicConsumer(channel);
            eventConsumer.Received += (ch, es) =>
            {
                var msg = Encoding.UTF8.GetString(es.Body.ToArray());
                Console.WriteLine($"Receive the message: {msg}");
                channel.BasicAck(es.DeliveryTag, false);
            };
            channel.BasicConsume("hello", false, eventConsumer);
            Console.WriteLine("Consumer has started");
            Console.Read();
            channel.Dispose();
            connection.Dispose();
        }
    }
}
