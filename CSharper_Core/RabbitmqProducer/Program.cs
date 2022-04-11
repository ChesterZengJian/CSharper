using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitmqProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://test:123456@chestervm-126.com:5672//")
            };

            const string queue = "chester.test.001";
            const string exchange = "exchange.chester.test.001";
            const string rk = "rk.chester.001";

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ConfirmSelect();
            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Direct, durable: false, autoDelete: false, arguments: null);
            channel.QueueBind(queue: queue, exchange: exchange, routingKey: rk, arguments: null);
            Console.WriteLine("RabbitMQ connection successfully");

            string input;
            do
            {
                input = Console.ReadLine();
                Console.WriteLine($"read line: {input}");
                var sendBytes = Encoding.UTF8.GetBytes(input);
                channel.BasicPublish(exchange: exchange + "error", routingKey: rk, basicProperties: null, body: sendBytes, mandatory: false);
                channel.WaitForConfirmsOrDie(new TimeSpan(0, 0, 5));
            } while (!string.IsNullOrEmpty(input) && !input.Trim().ToLower().Equals("exit"));

            channel.Close();
            connection.Close();
        }
    }
}
