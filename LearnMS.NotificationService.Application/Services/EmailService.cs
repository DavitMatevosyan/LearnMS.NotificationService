using System.Net.Http;
using System.Net.Mail;
using LearnMS.NotificationService.Application.Dtos;
using LearnMS.NotificationService.Contracts;
using LearnMS.NotificationService.Contracts.Services;
using LearnMS.NotificationService.Models.Exceptions;

namespace LearnMS.NotificationService.Application.Services;

public class EmailService : IEmailService
{
    private readonly IPublisher publisher;

    public EmailService(IPublisher publisher)
    {
        this.publisher = publisher;
    }

    public async Task<int> PushEmailAsync(MailObjectDto mailObject)
    {
        if (mailObject == null)
            throw new MailObjectNullException("The given mail data is null");

        // push to elastic search (non relation db) as log

        // push to smtp 
        await publisher.PublishAsync(mailObject);

        return 15;
    }
}