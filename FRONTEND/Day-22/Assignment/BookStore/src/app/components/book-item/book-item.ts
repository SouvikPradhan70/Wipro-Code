import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../models/book.model';
import { DiscountPipe } from '../../pipes/discount-pipe';

@Component({
  selector: 'app-book-item',
  standalone: true,
  imports: [CommonModule, DiscountPipe],
  templateUrl: './book-item.html',
  styleUrls: ['./book-item.css']
})
export class BookItemComponent {
  @Input() book!: Book;
}
