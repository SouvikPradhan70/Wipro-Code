import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Highlight } from './directives/highlight';
import { PriceFormatPipe } from './pipes/pipe-pipe';
import { Products } from './products/products';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Highlight, PriceFormatPipe, Products],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('new_file');
}
