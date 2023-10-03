using System.Net.Mail;
using LearnMS.NotificationService.Models.Serializables;
using LearnMS.NotificationService.Application.Dtos;
using System.Text;

namespace LearnMS.NotificationService.Models.MappingsHelper;

public static class MailObjectHelper
{
    public static SerializableMailMessage ToMailMessage(this MailObjectDto dto) 
    {
        var result = new SerializableMailMessage()
        {
            From = new MailAddress(dto.From.Address, dto.From.DisplayName),
            IsBodyHtml = dto.IsBodyHtml,
            Priority = dto.Priority,
            Body = dto.Body,
            BodyEncoding = Encoding.UTF8
        };

        foreach (var item in dto.To!)
        {
            result.To.Add(new MailAddress(item.Address, item.DisplayName));
        }

        foreach (var item in dto.CC ?? new())
        {
            result.CC.Add(new MailAddress(item.Address, item.DisplayName));
        }

        foreach (var item in dto.Bcc ?? new())
        {
            result.Bcc.Add(new MailAddress(item.Address, item.DisplayName));
        }

        if(dto.Attachments is not null) 
        {
            foreach (var item in dto.Attachments)
            {
                result.Attachments.Add(item);
            }
        }

        return result;
    }
}
