using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    public class Send
    {

        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Topic);

                    var routingKey = ((args.Length > 0) ? args[0] : "anonimous.info");
                    var message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "logs",
                                         routingKey: routingKey,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                }

                Console.WriteLine( "Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 1) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
