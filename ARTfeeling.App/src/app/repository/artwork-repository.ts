import { OnInit } from "@angular/core";
import { Observable } from "rxjs";

import { Artwork } from "../model/artwork"

export class ArtworkRepository implements OnInit {
    getArtwork() {
        const artworks = Observable.of<Artwork>(
            new { Id: 1 },

        );
    }
}
