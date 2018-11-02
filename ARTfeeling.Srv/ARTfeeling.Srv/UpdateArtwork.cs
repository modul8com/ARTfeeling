
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
using Microsoft.WindowsAzure.Storage.Table;
using ARTfeeling.Srv.model;

namespace ARTfeeling.Srv
{
    public static class UpdateArtwork
    {
        [FunctionName("UpdateArtwork")]
        public static async Task<IActionResult> RunUpdateArtwork(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "artwork/{id}")]HttpRequest req, 
            [Table("Artwork", Connection = "AzureWebJobsStorage")] CloudTable artworkTable,
            ILogger log, string id)
        {
            log.LogInformation($"Updating Artwork by id {id}");
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var updated = JsonConvert.DeserializeObject<Artwork>(body);
            var findOperation = TableOperation.Retrieve<ArtworkEntity>("Artwork", id);
            var findResult = await artworkTable.ExecuteAsync(findOperation);
            if (findResult.Result == null)
            {
                return new NotFoundResult();
            }

            var existingRow = (ArtworkEntity)findResult.Result;
            existingRow.Title = updated.Title;
            existingRow.Remarks = updated.Remarks;
            existingRow.Height = updated.Height;
            existingRow.Width = updated.Width;
            existingRow.Depth = updated.Depth;
            existingRow.TypeOfArtwork = (int)updated.TypeOfArtwork;
            existingRow.Pictures = updated.Pictures;
            existingRow.ExposedAtpartitionKey = updated.ExposedAtpartitionKey;
            existingRow.ExposedAtrowKey = updated.ExposedAtrowKey;

            var replaceOperation = TableOperation.Replace(existingRow);
            await artworkTable.ExecuteAsync(replaceOperation);
            return new OkObjectResult(existingRow.ToArtwork());
        }
    }
}
