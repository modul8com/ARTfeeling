import { Component, OnInit } from '@angular/core';
import { Artwork } from './model/artwork';
import { ArtworkRepository } from './repository/artwork-repository';

@Component({
  selector: 'modul8-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ARTfeeling';

  ngOnInit() {
    
  }  
}
