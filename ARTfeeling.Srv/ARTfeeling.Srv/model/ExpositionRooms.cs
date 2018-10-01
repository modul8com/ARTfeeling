using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARTfeeling.Srv.model
{
    public class ExpositionRooms
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
        [JsonProperty("community")]
        public string Community { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
