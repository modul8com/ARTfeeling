
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
using System.ComponentModel.DataAnnotations.Schema;
using ARTfeeling.Srv.model;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using TableAttribute = Microsoft.Azure.WebJobs.TableAttribute;

namespace ARTfeeling.Srv
{
    public static class GetArtworks
    {
        [FunctionName("GetArtworks")]
        public static async Task<IActionResult> RunGetArtworks(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "artwork")]HttpRequest req,
            [Table("Artwork", Connection = "AzureWebJobsStorage")] CloudTable artworkTable,
            ILogger log)
        {
            log.LogInformation("Retrieving list of Artworks");

            var query = new TableQuery<ArtworkEntity>();
            var segment = await artworkTable.ExecuteQuerySegmentedAsync(query, null);
            log.LogInformation("Found {0} artworks", segment.Results.Count);
            return new OkObjectResult(segment.Select(Mappings.ToArtwork));
        }
    }
}
