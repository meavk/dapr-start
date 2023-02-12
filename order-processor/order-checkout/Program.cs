using Abstractions;

using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddW3CLogging(o => {
    o.LoggingFields = Microsoft.AspNetCore.HttpLogging.W3CLoggingFields.All;
});
builder.Logging.AddJsonConsole(o => o.IncludeScopes = true);

string ORDER_PROCESSOR_NAME = "orderapp";


var app = builder.Build();

using var client = new DaprClientBuilder().Build();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("order-checkout");

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

app.MapPost("/checkout", async (HttpContext context, List<int> items) =>
{
    var order = new Order
    {
        OrderId = Guid.NewGuid().ToString(),
        Items = items,
        CustomerName = "Same Customer"
    };

    var result = await client.InvokeMethodAsync<Order, Order>(ORDER_PROCESSOR_NAME, "orders", order);
    logger.LogInformation($"Order checked out:{result.OrderId}");
    await context.Response.WriteAsJsonAsync(result);
});

await app.RunAsync();
