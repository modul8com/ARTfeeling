import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { ArtworkRepository } from './repository/artwork-repository';

@NgModule({
  declarations: [
    AppComponent,
    PortfolioComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [ ArtworkRepository ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
