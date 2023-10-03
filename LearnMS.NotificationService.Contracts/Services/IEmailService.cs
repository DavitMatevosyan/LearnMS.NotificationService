using LearnMS.NotificationService.Application.Dtos;

namespace LearnMS.NotificationService.Contracts.Services;

public interface IEmailService
{
    Task<int> PushEmailAsync(MailObjectDto mailObject);
}
