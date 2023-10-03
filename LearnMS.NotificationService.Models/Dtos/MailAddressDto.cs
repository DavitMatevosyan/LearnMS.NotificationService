namespace LearnMS.NotificationService.Application.Dtos;

public class MailAddressDto
{
    public string Address { get; set; } = null!; // email
    public string DisplayName { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
}
