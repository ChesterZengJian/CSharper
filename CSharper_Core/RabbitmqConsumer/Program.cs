using RabbitMQ.Client;
using System;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RabbitmqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://test:123456@chestervm-126.com:5672//")
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var eventConsumer = new EventingBasicConsumer(channel);

            const string queue = "chester.test.001";

            eventConsumer.Received += (model, deliverEventArgs) =>
            {
                var msg = Encoding.UTF8.GetString(deliverEventArgs.Body.ToArray());
                Console.WriteLine($"Receive the message: {msg}, {nameof(deliverEventArgs.DeliveryTag)}: {deliverEventArgs.DeliveryTag}");
                channel.BasicNack(deliveryTag: deliverEventArgs.DeliveryTag, multiple: false, requeue: false);
                channel.BasicReject(deliveryTag: deliverEventArgs.DeliveryTag, requeue: false);
                //channel.BasicAck(deliveryTag: deliverEventArgs.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queue: queue, autoAck: false, consumer: eventConsumer);

            // 只获取数据不将数据从队列删除
            //var result = channel.BasicGet(queue: queue, autoAck: false);
            //var msg = Encoding.UTF8.GetString(result.Body.ToArray());
            //Console.WriteLine($"Receive the message: {msg}, {nameof(result.DeliveryTag)}: {result.DeliveryTag}");

            Console.WriteLine("Consumer has started");
            Console.Read();
            channel.Dispose();
            connection.Dispose();
        }
    }
}
