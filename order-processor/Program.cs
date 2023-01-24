using Dapr.Client;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

string DAPR_STORE_NAME = "statestore";

var app = builder.Build();

using var client = new DaprClientBuilder().Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/health", async (HttpContext context, int id) =>
{
    await context.Response.WriteAsync("Running");
});

app.MapGet("/orders/{id}", async (HttpContext context, int id) =>
{
    var order = await client.GetStateAsync<Order>(DAPR_STORE_NAME, id.ToString());
    await context.Response.WriteAsJsonAsync(order);
});

app.MapPost("/orders", async (HttpContext context, Order order) =>
{
    await client.SaveStateAsync(DAPR_STORE_NAME, order.OrderId.ToString(), order);
    await context.Response.WriteAsJsonAsync(order);
});

await app.RunAsync();

public record Order(int OrderId, string CustomerName);
