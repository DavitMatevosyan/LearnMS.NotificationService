using LearnMS.NotificationService.Contracts;
using RabbitMQ.Client;
using System.Text;

namespace LearnMS.NotificationService.SMTP.Publisher.Services
{
    public class SMTPPublisher : IPublisher
    {
        public async Task Publish()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            const string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message); // todo: store in the noSQL db the data

            channel.BasicPublish(exchange: string.Empty,
                             routingKey: "hello",
                             basicProperties: null,
                             body: body);

            // Stopped Here: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
        }
    }
}
