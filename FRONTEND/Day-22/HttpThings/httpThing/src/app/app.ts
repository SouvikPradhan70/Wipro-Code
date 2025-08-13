import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Posts } from './posts/posts';
import { Data } from './data';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,BrowserModule,HttpClientModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('httpThing');

  post$= this.dataservice

  
}
