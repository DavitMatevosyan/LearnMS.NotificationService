using System.Net.Mail;
using LearnMS.NotificationService.Application.Dtos;

namespace LearnMS.NotificationService.Contracts
{
    public interface IPublisher
    {
        Task PublishAsync(MailObjectDto message);
    }
}
