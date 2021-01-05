using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SharedDll;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api
{
    public class Function1
    {
        [FunctionName("GamificationListDestaques")]
        public async Task<IActionResult> ListDestaques(
           [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "Gamification/ListDestaques")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var result = ProfileSeed.GetProfileSearch().Generate(24);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}