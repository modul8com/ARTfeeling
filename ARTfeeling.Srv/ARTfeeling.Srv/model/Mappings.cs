using System;
using System.Collections.Generic;
using System.Text;

namespace ARTfeeling.Srv.model
{
    public static class Mappings
    {
        public static ArtworkEntity ToArtworkEntity(this Artwork artwork)
        {
            return new ArtworkEntity()
            {
                PartitionKey = "Artwork",
                RowKey = artwork.Id.ToString("B"),

                Title = artwork.Title,
                Remarks = artwork.Remarks,
                Height = artwork.Height,
                Width = artwork.Width,
                Depth = artwork.Depth,
                TypeOfArtwork = (int)artwork.TypeOfArtwork,

                Pictures = artwork.Pictures,

                ExposedAtpartitionKey = artwork.ExposedAtpartitionKey,
                ExposedAtrowKey = artwork.ExposedAtrowKey,

                Price = artwork.Price
            };
        }

        public static Artwork ToArtwork(this ArtworkEntity artwork)
        {
            return new Artwork()
            {
                Id = Guid.Parse(artwork.RowKey),

                Title = artwork.Title,
                Remarks = artwork.Remarks,
                Height = artwork.Height,
                Width = artwork.Width,
                Depth = artwork.Depth,
                TypeOfArtwork = (ArtType)artwork.TypeOfArtwork,

                Pictures = artwork.Pictures,

                ExposedAtpartitionKey = artwork.ExposedAtpartitionKey,
                ExposedAtrowKey = artwork.ExposedAtrowKey,

                Price = artwork.Price
            };
        }
    }
}
