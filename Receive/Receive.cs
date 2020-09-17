using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Receive
{
    public class Receive
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){ HostName = "localhost"};
            
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Direct);

                    var queueName = channel.QueueDeclare().QueueName;

                    foreach(var severity in args)
                    {
                        channel.QueueBind(queue: queueName,
                                      exchange: "logs",
                                      routingKey: severity);
                    }

                    Console.WriteLine(" [*] Waiting for messages.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine( " [x] Received {0}", message);

                    };
                    channel.BasicConsume(queue: queueName,
                                          autoAck: true,
                                          consumer: consumer);                    

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
