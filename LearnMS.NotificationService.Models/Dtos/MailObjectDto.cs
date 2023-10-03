using System.Net.Mail;

namespace LearnMS.NotificationService.Application.Dtos;

public class MailObjectDto
{
    public MailAddressDto From { get; set; } = null!;
    public MailAddressCollectionDto? To { get; set; }
    public MailAddressCollectionDto? Bcc { get; set; }
    public MailAddressCollectionDto? CC { get; set; }
    public MailPriority Priority { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public bool IsBodyHtml { get; set; }
    public AttachmentCollection? Attachments { get; set; }
}