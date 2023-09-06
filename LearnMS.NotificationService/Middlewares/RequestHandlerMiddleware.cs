using LearnMS.NotificationService.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace LearnMS.NotificationService.Middlewares
{
    public class RequestHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IServiceProvider _serviceProvider;

        public RequestHandlerMiddleware(
            RequestDelegate requestDelegate, 
            IServiceProvider serviceProvider)
        {
            _requestDelegate = requestDelegate;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var handler = GetHandlerForRoute(context.Request.Path);

            if (handler == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            await handler.HandleAsync(context);
        }

        private IRequestHandler GetHandlerForRoute(string route)
        {
            // store this in appsettings.json
            var routes = new Dictionary<string, IRequestHandler>()
            {
                {"api/sendEmail", _serviceProvider.GetRequiredService<SendEmailHandler>() }
            };

            if (!routes.ContainsKey(route))
                throw new Exception("Implement Route Not Found Exception");

            return routes[route];
        }
    }
}
