using Microsoft.WindowsAzure.Storage.Table;

namespace ARTfeeling.Srv.model
{
    public class ExpositionRoom : TableEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Community { get; set; }
        public string Country { get; set; }
        public string Url { get; set; }
    }
}
