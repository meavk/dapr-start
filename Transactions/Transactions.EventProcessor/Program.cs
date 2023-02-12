using Dapr;
using Dapr.Client;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddW3CLogging(o => {
    o.LoggingFields = Microsoft.AspNetCore.HttpLogging.W3CLoggingFields.All;
});
builder.Logging.AddJsonConsole(o => o.IncludeScopes = true);

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

var client = new DaprClientBuilder().Build();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("order-checkout");

app.MapGet("/health", async (HttpContext context) =>
{
    logger.LogInformation("Running health check.");
    await context.Response.WriteAsync("Running");
});

app.MapPost("/receive", [Topic("servicebus-pubsub", "transation2")] async (TransactionEvent transaction) => {
    logger.LogInformation($"Received transaction event: {transaction.Id}");
    return Results.Ok();
});

app.RunAsync();

public record TransactionEvent([property: JsonPropertyName("id")] int Id);
