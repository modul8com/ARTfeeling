using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARTfeeling.Srv.model
{
    public class ArtworkEntity : TableEntity
    {
        public string Title { get; set; }
        public string Remarks { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int TypeOfArtWork { get; set; }

        public string[] Pictures { get; set; }

        public string ExposedAtpartitionKey { get; set; }
        public string ExposedAtrowKey { get; set; }
    }
}
