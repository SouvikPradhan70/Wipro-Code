import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'discount',
  standalone: true
})
export class DiscountPipe implements PipeTransform {
  transform(price: number, percent: number = 0): number {
    if (typeof price !== 'number' || typeof percent !== 'number') return price;
    const clamped = Math.min(Math.max(percent, 0), 100);
    return +(price * (1 - clamped / 100)).toFixed(2);
  }
}
