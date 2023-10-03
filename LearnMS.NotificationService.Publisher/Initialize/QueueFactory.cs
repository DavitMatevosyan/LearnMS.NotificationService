using LearnMS.NotificationService.Contracts;
using LearnMS.NotificationService.Models.Serializables;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace LearnMS.NotificationService.SMTP.Publisher.Initialize
{
    public class QueueFactory : IQueueFactory
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ConnectionFactory ConnectionFactory => _connectionFactory;
        public QueueFactory()
        {
            _connectionFactory = new ConnectionFactory()
            {
                // HostName = "localhost", // move to appsettings
                Uri = new Uri("amqp://admin:admin1@localhost:5672/")
            };

            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            CreateExchange(name: "ex-email",// move configurations to appsettings
                           type: ExchangeType.Direct);

            CreateQueue(name: "q-email-basic",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            BindQueueExchange("q-email-basic", "ex-email", "basic-send", null); // move every single string to appsettings

            // channel.BasicPublish to push to queue
        }

        public void CreateExchange(string name, string type, bool durable = true, bool autoDelete = false, Dictionary<string, object>? arguments = null)
                => _channel.ExchangeDeclare(name, type, durable, autoDelete, arguments);

        public void CreateQueue(string name, bool durable = true, bool exclusive = false, bool autoDelete = false, Dictionary<string, object>? arguments = null)
                => _channel.QueueDeclare(name, durable, exclusive, autoDelete, arguments);

        public void BindQueueExchange(string queue, string exchange, string routingKey, Dictionary<string, object>? arguments = null)
                => _channel.QueueBind(queue, exchange, routingKey, arguments);

        public async Task Push(SerializableMailMessage mail, string exchange = "ex-email", string routingKey = "basic-send", bool mandatory = false, IBasicProperties? basicProperties = null)
        {
            await Task.Run(() =>
            {
                var serializedMail = JsonSerializer.Serialize(mail);
                var bodyBytes = Encoding.UTF8.GetBytes(serializedMail);

                _channel.BasicPublish(exchange, routingKey, mandatory, basicProperties, bodyBytes);
            });

        }     
    }
}
