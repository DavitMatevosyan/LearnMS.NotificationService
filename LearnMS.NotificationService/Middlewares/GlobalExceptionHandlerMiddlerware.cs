using LearnMS.NotificationService.API.Models;
using LearnMS.NotificationService.Models.Exceptions;
using System.Net;

namespace LearnMS.NotificationService.API.Middlewares
{
    public class GlobalExceptionHandlerMiddlerware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public GlobalExceptionHandlerMiddlerware(RequestDelegate next, Serilog.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.Information("init LearnMS.NotificationService");
                await _next(context);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Something went wrong");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex is MailObjectNullException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var details = new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(details);
            }
        }
    }
}
