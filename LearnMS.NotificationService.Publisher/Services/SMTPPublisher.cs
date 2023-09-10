using LearnMS.NotificationService.Contracts;
using LearnMS.NotificationService.SMTP.Publisher.Initialize;
using System.Net.Mail;
using System.Text;

namespace LearnMS.NotificationService.SMTP.Publisher.Services
{
    public class SMTPPublisher : IPublisher
    {
        private QueueFactory _queue;

        public SMTPPublisher(QueueFactory queue)
        {
            _queue = queue;
        }

        public async Task Publish()
        {
            MailMessage mail = new MailMessage();


            
            await _queue.Push(mail); // todo target, optional exchange names, headers, routingkey
            
        }
    }
}
