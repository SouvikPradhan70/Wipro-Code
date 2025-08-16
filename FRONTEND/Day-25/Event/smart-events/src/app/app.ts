import { Component, signal } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; // ✅ added

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    DatePipe,
    HttpClientModule // ✅ include HttpClientModule for your Events service
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.scss'] // ✅ fixed to plural
})
export class App {
  today = new Date();
  protected readonly title = signal('smart-events');
}

