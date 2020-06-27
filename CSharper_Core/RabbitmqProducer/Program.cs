using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitmqProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionFacotory = new ConnectionFactory
            {
                UserName = "chester",
                Password = "123456",
                HostName = "192.168.3.125"
            };
            var connection = connectionFacotory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("hello", false, false, false, null);
            Console.WriteLine("\nRabbitMQ connection successfully");

            string input;
            do
            {
                input = Console.ReadLine();
                var sendBytes = Encoding.UTF8.GetBytes(input);
                channel.BasicPublish("", "hello", null, sendBytes);
            } while (!input.Trim().ToLower().Equals("exit"));

            channel.Close();
            connection.Close();
        }
    }
}
