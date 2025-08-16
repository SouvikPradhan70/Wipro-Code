import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService } from '../../services/data';
import { Book } from '../../models/book.model';
import { Observable, Subject } from 'rxjs';
import { shareReplay, takeUntil } from 'rxjs/operators';
import { BookItemComponent } from '../book-item/book-item';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, BookItemComponent],
  templateUrl: './books.html',
  styleUrls: ['./books.css']
})
export class BooksComponent implements OnInit, OnDestroy {
  books$!: Observable<Book[]>;
  manualBooks: Book[] = [];
  private destroy$ = new Subject<void>();

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    const shared$ = this.dataService.getBooks().pipe(shareReplay(1));
    this.books$ = shared$;

    shared$.pipe(takeUntil(this.destroy$)).subscribe({
      next: (books) => (this.manualBooks = books),
      error: (err) => console.error('Error fetching books:', err)
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
