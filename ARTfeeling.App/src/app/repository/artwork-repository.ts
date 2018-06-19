import { OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Artwork } from '../model/artwork';

export class ArtworkRepository implements OnInit {
    getArtwork() {
        const artworks = of<Artwork>(
            

        );
    }

    ngOnInit() {

    }
}
