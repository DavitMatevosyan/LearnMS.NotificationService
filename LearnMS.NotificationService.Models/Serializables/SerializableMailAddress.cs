using System.Net.Mail;
using System.Runtime.Serialization;

namespace LearnMS.NotificationService.Models.Serializables;

[Serializable]
public class SerializableMailAddress : MailAddress, ISerializable
{
    public SerializableMailAddress(string address)
        : base(address)
    {
    }

    public SerializableMailAddress(string address, string displayName)
        : base(address, displayName)
    {
    }

    // Implement the ISerializable interface
    public SerializableMailAddress(SerializationInfo info, StreamingContext context)
        : base(info.GetString("Address")!, info.GetString("DisplayName")!)
    {
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Address", Address);
        info.AddValue("DisplayName", DisplayName);
    }
}