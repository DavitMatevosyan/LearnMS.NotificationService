using System.Net.Mail;
using System.Runtime.Serialization;

namespace LearnMS.NotificationService.Models.Serializables;

[Serializable]
public class SerializableMailMessage : MailMessage, ISerializable
{
    public SerializableMailMessage()
    {
    }

    // Implement the ISerializable interface
    protected SerializableMailMessage(SerializationInfo info, StreamingContext context)
        : base()
    {
        // Deserialize the properties of the MailMessage
        From = new SerializableMailAddress(info.GetString("From")!);
        Subject = info.GetString("Subject");
  //     Body = info.GetString("Body");
        // Deserialize other properties as needed
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // Serialize the properties of the MailMessage
        info.AddValue("From", From!.ToString());
        info.AddValue("Subject", Subject);
 //       info.AddValue("Body", Body);
        // Serialize other properties as needed
    }
}