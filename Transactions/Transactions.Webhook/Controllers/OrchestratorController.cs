using Microsoft.AspNetCore.Mvc;

using System.Text.Json.Serialization;

namespace Transactions.Webhook.Controllers
{
    [ApiController]
    [Route("transactions")]
    public class OrchestratorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<OrchestratorController> _logger;

        public OrchestratorController(ILogger<OrchestratorController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "event")]
        public async Task<IActionResult> OrchestratorEvent(TransactionEvent payload)
        {
            return await Task.FromResult(NoContent());
        }
    }

    public record TransactionEvent([property: JsonPropertyName("transactionId")] string TransactionId);
}