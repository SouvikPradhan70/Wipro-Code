import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './components/books/books';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, BooksComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {}
