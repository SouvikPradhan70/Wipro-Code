import { Component } from '@angular/core';

@Component({
  selector: 'app-book',
  standalone: true,
  templateUrl: './book.html',
  styleUrls: ['./book.css']
})
export class BookComponent {
  productName = 'IKIGAI';
  productPrice = 40;
  addedToCart = false;

  addToCart() {
    this.addedToCart = true;
  }
}
