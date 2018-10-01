
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
using Microsoft.WindowsAzure.Storage;

namespace ARTfeeling.Srv
{
    public static class DeleteArtwork
    {
        [FunctionName("DeleteArtwork")]
        public static async Task<IActionResult> RunDeleteArtwork(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "artwork/{id}")] HttpRequest req,
            [Table("Artwork", Connection = "AzureWebJobsStorage")] CloudTable artworkTable, 
            ILogger log, string id)
        {
            log.LogInformation($"Deleting Artwork by id {id}");

            var deleteOperation = TableOperation.Delete(new TableEntity() { PartitionKey = "Artwork", RowKey = id, ETag = "*" });
            try
            {
                var deleteResult = await artworkTable.ExecuteAsync(deleteOperation);
            }
            catch (StorageException e) when (e.RequestInformation.HttpStatusCode == 404)
            {
                return new NotFoundResult();
            }
            return new OkResult();
        }
    }
}
