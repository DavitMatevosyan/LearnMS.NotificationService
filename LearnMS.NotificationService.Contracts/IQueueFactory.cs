using RabbitMQ.Client;
using System.Net.Mail;

namespace LearnMS.NotificationService.Contracts
{
    public interface IQueueFactory
    {
        ConnectionFactory ConnectionFactory { get; }

        /// <summary>
        /// Binds the <paramref name="queue"/> with the <paramref name="exchange"/> using <paramref name="routingKey"/> key
        /// </summary>
        /// <param name="queue">Name of the queue</param>
        /// <param name="queue">Name of the exchange</param>
        /// <param name="routingKey">Routing key</param>
        /// <param name="arguments">Additional arguments</param>
        void BindQueueExchange(string queue, string exchange, string routingKey, Dictionary<string, object>? arguments = null);

        /// <summary>
        /// Creates an exchange with the given parameters
        /// </summary>
        /// <param name="name">Name of the exchange</param>
        /// <param name="type">Type of the exchange ("direct", "headers", "fanout","topic")</param>
        /// <param name="durable">Shows whether the exchange will survive a broker restart</param>
        /// <param name="autodelete">Shows whether this exchange will be auto-deleted when its last consumer (if any) unsubscribes?</param>
        /// <param name="arguments">Additional arguments</param>
        void CreateExchange(string name, string type, bool durable = false, bool autoDelete = false, Dictionary<string, object>? arguments = null);

        /// <summary>
        /// Creates a queue with the given parameters
        /// </summary>
        /// <param name="name">Name of the queue</param>
        /// <param name="durable">Shows whether the queue will survive a broker restart</param>
        /// <param name="exclusive">Should this queue use be limited to its declaring connection? Such a queue will be deleted when its declaring connection closes.</param>
        /// <param name="autodelete">Shows whether this queue will be auto-deleted when its last consumer (if any) unsubscribes?</param>
        /// <param name="arguments">Additional arguments</param>
        void CreateQueue(string name, bool durable = true, bool exclusive = false, bool autoDelete = false, Dictionary<string, object>? arguments = null);
        
        /// <summary>
        /// Pushes the given <paramref name="mail"/> to the given <paramref name="exchange"/> with the <paramref name="routingKey"/>
        /// </summary>
        /// <param name="mail">Given mail object</param>
        /// <param name="exchange">The exchange</param>
        /// <param name="routingKey">The routing key</param>
        /// <param name="mandatory"></param>
        /// <param name="basicProperties"></param>
        /// <returns></returns>
        Task Push(MailMessage mail, string exchange = "ex-email", string routingKey = "basic-send", bool mandatory = false, IBasicProperties? basicProperties = null);
    }
}
