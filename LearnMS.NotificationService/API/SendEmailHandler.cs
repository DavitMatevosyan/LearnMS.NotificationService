namespace LearnMS.NotificationService.API
{
    public class SendEmailHandler : IRequestHandler
    {
        public async Task HandleAsync(HttpContext context)
        {
            // Handle the logic for sending an email.
            await context.Response.WriteAsync("Email sent.");
        }
    }
}
