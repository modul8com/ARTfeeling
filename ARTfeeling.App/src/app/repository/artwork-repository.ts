import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ArtworkRepository {
    constructor(private http: HttpClient) { }

    getArtworks() {
        return this.http.get('https://artfeelingsrvr.azurewebsites.net/api/artwork?code=uQqDuVYNVG7OPCwep7mGkm3eJD9W60BQsU0xSsuQrKrIiQjax/ePhw==');
    }
}
