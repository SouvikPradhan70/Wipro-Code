import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ProductDetails } from '../product-details/product-details';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ProductDetails],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class Dashboard {
  products = [
    { name: 'Laptop', price: 50000 },
    { name: 'Mobile', price: 40000 },
    { name: 'Tablet', price: 35000 }
  ];

  selectedProduct: any = null;
  feedbackList: string[] = [];

  selectProduct(product: any) {
    this.selectedProduct = product;
  }

  receiveFeedback(feedback: any) {
    this.feedbackList.push(feedback as string);
  }
}
