import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Dashboard],
  templateUrl: './app.html',
  styleUrls: ['./app.css'] // ✅ plural form
})
export class App {
  protected readonly title = signal('dashProd');
}
