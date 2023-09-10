namespace LearnMS.NotificationService.Application.Dtos;

public class MailAddressDto
{
    public string DisplayName { get; set; } = string.Empty; // email
    public string Username { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
}
