import { Component, OnInit } from '@angular/core';
import { ArtworkRepository } from '../repository/artwork-repository';
import { Artwork } from '../model/artwork';

@Component({
  selector: 'modul8-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent implements OnInit {

  portfolio: Artwork[];

  constructor(private repo: ArtworkRepository) { }

  ngOnInit() {
    this.repo.getArtworks().subscribe((data: Artwork[]) => {
        this.portfolio = data;
      },
      error => {
        console.log(error);
      }
    );
  }

}
