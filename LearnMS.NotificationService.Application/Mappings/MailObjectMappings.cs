using AutoMapper;
using LearnMS.NotificationService.Application.Dtos;
using System.Net.Mail;

namespace LearnMS.NotificationService.Application.Mappings;

public class MailObjectMappings : Profile
{
    public MailObjectMappings()
    {
        CreateMap<MailAddressDto, MailAddress>()
            .ForMember(x => x, x => x.MapFrom(s => new MailAddress(s.Address, s.DisplayName)));

        CreateMap<MailAddressCollectionDto, MailAddressCollection>()
            .ForMember(x => x, x => x.MapFrom(s => s.Select(y => new MailAddress(y.Address, y.DisplayName))));

        CreateMap<MailObjectDto, MailMessage>()
            .ForMember(x => x, x => x.MapFrom(s => new MailMessage(s.From!.Address, s.To!.ToString())));
    }
}
