using LearnMS.NotificationService.API.Middlewares;
using LearnMS.NotificationService.Application.Dtos;
using LearnMS.NotificationService.Application.Mappings;
using LearnMS.NotificationService.Application.Services;
using LearnMS.NotificationService.Contracts.Services;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog((context, config) =>
        {
            config.Enrich.FromLogContext()
                .MinimumLevel.Information()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticSearch:Uri"]!))
                {
                    IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1,
                    ModifyConnectionSettings = config => config.CertificateFingerprint(context.Configuration["ElasticSearch:Certificate"])

                })
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName!)
                .ReadFrom.Configuration(context.Configuration);
        });

    builder.Services.AddAutoMapper(typeof(MailObjectMappings));

    builder.Services.AddScoped<IEmailService, EmailService>();
}

var app = builder.Build();
{
    app.UseSwagger();

    app.UseSwaggerUI(x =>
    {
        x.DocumentTitle = "Notification Service";
    });



    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<GlobalExceptionHandlerMiddlerware>();

    app.UseHttpsRedirection();

    app.MapPost("api/sendEmail", async (MailObjectDto mailObject, IEmailService emailService)
        => await emailService.PushEmailAsync(mailObject));

    app.Run();
}

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();


