import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import{Parent} from './parent/parent';


@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet,Parent],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('DataBin');
}
