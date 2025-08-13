import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-details.html',
  styleUrls: ['./product-details.css']
})
export class ProductDetails {
  @Input() product: any;
  @Output() feedbackEvent = new EventEmitter<string>();

  feedbackText: string = '';

  sendFeedBack() {
    if (this.feedbackText.trim()) {
      this.feedbackEvent.emit(`${this.product.name}:${this.feedbackText}`);
      this.feedbackText = '';
    }
  }
}
