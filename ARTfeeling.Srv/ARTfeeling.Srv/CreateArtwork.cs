
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
    public static class CreateArtwork
    {
        [FunctionName("CreateArtwork")]
        public static async Task<IActionResult> RunCreateArtwork(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "artwork")] HttpRequest req,
            [Table("Artwork", Connection = "AzureWebJobsStorage")] IAsyncCollector<ArtworkEntity> artworkTable,
            ILogger log)
        {
            log.LogInformation("Creating new artwork");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var artwork = JsonConvert.DeserializeObject<Artwork>(requestBody);
            await artworkTable.AddAsync(artwork.ToArtworkEntity());
            return new OkObjectResult(artwork);
        }
    }
}
