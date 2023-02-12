using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using System.Text.Json.Serialization;

using Transactions.Abstractions;

namespace Transactions.Facade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Transaction> Get(string id)
        {
            var result = JsonSerializer.Deserialize<Transaction>(Constants.SampleTransactionJson);
            if (result != null)
            {
                result.id = id;
            }

            return await Task.FromResult(result!);
        }
    }
}