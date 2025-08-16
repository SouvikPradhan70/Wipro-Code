import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'monthFilter'
})
export class MonthFilterPipe implements PipeTransform {

  // transform(value: unknown, ...args: unknown[]): unknown {
  //   return null;
  // }

  transform<T extends{date?: string}>(items: T[], month?: number): T[]{
    if(!Array.isArray(items) || month==null) return items;
    return items.filter(i => {
      const d=i?.date ? new Date(i.date): null;
      return d && d.getMonth() === month;
    });

  }

}
