
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ARTfeeling.Srv.model;

namespace ARTfeeling.Srv
{
    public static class GetArtworkById
    {
        [FunctionName("GetArtworkById")]
        public static IActionResult RunGetArtworkById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "artwork/{id}")] HttpRequest req,
            [Table("Artwork", "Artwork", "{id}", Connection = "AzureWebJobsStorage")] ArtworkEntity artwork,
            ILogger log, string id)
        {
            log.LogInformation($"Retrieving artwork by id {id}");
            if (artwork == null)
            {
                log.LogError($"Artwork with id {id} not found");
                return new NotFoundResult();
            }

            return new OkObjectResult(artwork.ToArtwork());
        }
    }
}
