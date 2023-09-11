namespace LearnMS.NotificationService.Application.Dtos;

public class MailAddressDto
{
    public string Address { get; set; } = string.Empty; // email
    public string DisplayName { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
}
