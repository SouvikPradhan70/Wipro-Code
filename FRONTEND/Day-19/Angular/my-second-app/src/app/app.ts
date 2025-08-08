import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookComponent } from './book/book';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,BookComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('my-second-app');
}
