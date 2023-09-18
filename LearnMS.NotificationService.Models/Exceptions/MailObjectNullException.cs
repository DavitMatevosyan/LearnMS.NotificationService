namespace LearnMS.NotificationService.Models.Exceptions
{
    public class MailObjectNullException : Exception
    {
        public MailObjectNullException() : base() { }

        public MailObjectNullException(string message) : base(message) { }

        public MailObjectNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
