using LearnMS.NotificationService.Application.Dtos;
using LearnMS.NotificationService.Contracts.Services;
using LearnMS.NotificationService.Models.Exceptions;

namespace LearnMS.NotificationService.Application.Services;

public class EmailService : IEmailService
{
    public async Task PushEmailAsync(MailObjectDto mailObject)
    {
        if (mailObject == null)
            throw new MailObjectNullException("The given mail data is null");

        // push to elastic search (non relation db) as log

     
        // push to smtp 
    }
}
