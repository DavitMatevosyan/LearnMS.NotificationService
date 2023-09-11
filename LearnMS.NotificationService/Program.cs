using LearnMS.NotificationService.Application.Dtos;
using LearnMS.NotificationService.Contracts.Services;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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


