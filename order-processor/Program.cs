using Abstractions;

using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddW3CLogging(o => {
    o.LoggingFields = Microsoft.AspNetCore.HttpLogging.W3CLoggingFields.All;
});
builder.Logging.AddJsonConsole(o => o.IncludeScopes = true);

string DAPR_STORE_NAME = "statestore";

var app = builder.Build();

using var client = new DaprClientBuilder().Build();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("order-processor");

app.UseW3CLogging();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/health", async (HttpContext context) =>
{
    logger.LogInformation("Running health check.");
    await context.Response.WriteAsync("Running");
});

app.MapGet("/orders/{id}", async (HttpContext context, string id) =>
{
    var order = await client.GetStateAsync<Order>(DAPR_STORE_NAME, id);
    await context.Response.WriteAsJsonAsync(order);
});

app.MapPost("/orders", async (HttpContext context, Order order) =>
{
    await client.SaveStateAsync(DAPR_STORE_NAME, order.OrderId, order);
    logger.LogInformation($"Order processed:{order.OrderId}");
    await context.Response.WriteAsJsonAsync(order);
});

await app.RunAsync();
