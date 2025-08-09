import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'priceFormat'
})
export class PriceFormatPipe implements PipeTransform {
  transform(value: number | null | undefined, currency: string = 'USD', locale: string = 'en-US'): string {
    if (value == null || isNaN(Number(value))) return '';
    try {
      return new Intl.NumberFormat(locale, { style: 'currency', currency }).format(value);
    } catch (e) {
      // Fallback simple format
      return `${currency} ${value.toFixed(2)}`;
    }
  }
}