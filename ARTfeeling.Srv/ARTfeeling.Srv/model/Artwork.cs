using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARTfeeling.Srv.model
{
    public class Artwork
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("depth")]
        public int Depth { get; set; }
        [JsonProperty("typeOfArtWork")]
        public ArtType TypeOfArtWork { get; set; }

        [JsonProperty("pictures")]
        public string[] Pictures { get; set; }

        [JsonProperty("exposedAtpartitionKey")]
        public string ExposedAtpartitionKey { get; set; }
        [JsonProperty("exposedAtrowKey")]
        public string ExposedAtrowKey { get; set; }
    }
}
