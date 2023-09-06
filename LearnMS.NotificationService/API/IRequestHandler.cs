namespace LearnMS.NotificationService.API
{
    public interface IRequestHandler
    {
        Task HandleAsync(HttpContext context);
    }
}
