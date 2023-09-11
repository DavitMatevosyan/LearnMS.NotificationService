using LearnMS.NotificationService.Application.Dtos;
using LearnMS.NotificationService.Contracts.Services;

namespace LearnMS.NotificationService.Application.Services;

public class EmailService : IEmailService
{
    public Task PushEmailAsync(MailObjectDto mailObject)
    {
        
    }
}
