import { Directive, ElementRef, HostListener, Input, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class Highlight {
  @Input('appHighlight') highlightColor: string = '#ffffcc'; // default

  private originalBackground: string = '';

  constructor(private el: ElementRef, private renderer: Renderer2) {
    // capture any inline background if present
    this.originalBackground = this.el.nativeElement.style.backgroundColor || '';
  }

  // mouse enter hover effect
  @HostListener('mouseenter') onEnter() {
    this.renderer.setStyle(this.el.nativeElement, 'backgroundColor', this.highlightColor);
    this.renderer.setStyle(this.el.nativeElement, 'boxShadow', '0 6px 14px rgba(0, 0, 0, 0.08)');
    this.renderer.setStyle(this.el.nativeElement, 'transform', 'translateY(-3px)');
  }

  // mouse leave hover effect
  @HostListener('mouseleave') onLeave() {
    this.renderer.setStyle(this.el.nativeElement, 'backgroundColor', this.originalBackground);
    this.renderer.removeStyle(this.el.nativeElement, 'boxShadow');
    this.renderer.removeStyle(this.el.nativeElement, 'transform');
  }
}
