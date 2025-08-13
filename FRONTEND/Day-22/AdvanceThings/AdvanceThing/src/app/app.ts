import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import{Pipes} from './pipes/pipes';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Pipes],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('AdvanceThing');
}
