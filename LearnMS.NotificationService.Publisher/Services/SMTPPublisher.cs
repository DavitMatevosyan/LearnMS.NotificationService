using LearnMS.NotificationService.Application.Dtos;
using LearnMS.NotificationService.Contracts;
using LearnMS.NotificationService.Models.MappingsHelper;
using LearnMS.NotificationService.Models.Serializables;
using System.Net.Mail;

namespace LearnMS.NotificationService.SMTP.Publisher.Services
{
    public class SMTPPublisher : IPublisher
    {
        private IQueueFactory _queue;

        public SMTPPublisher(IQueueFactory queue)
        {
            _queue = queue;
        }

        public async Task PublishAsync(MailObjectDto message)
        {   
            var serializableMail = message.ToMailMessage();

            await _queue.Push(serializableMail); // todo target, optional exchange names, headers, routingkey            
        }
    }
}
