using System.Collections.ObjectModel;

namespace LearnMS.NotificationService.Application.Dtos;

public class MailAddressCollectionDto : Collection<MailAddressDto>
{
    public override string ToString() => string.Join(", ", this);

}
