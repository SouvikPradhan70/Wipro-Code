import { Highlight } from './highlight';
import { ElementRef, Renderer2 } from '@angular/core';

describe('Highlight Directive', () => {
  let mockElementRef: ElementRef;
  let mockRenderer: Renderer2;

  beforeEach(() => {
    mockElementRef = new ElementRef(document.createElement('div'));
    mockRenderer = jasmine.createSpyObj('Renderer2', ['setStyle', 'removeStyle']);
  });

  it('should create an instance', () => {
    const directive = new Highlight(mockElementRef, mockRenderer);
    expect(directive).toBeTruthy();
  });

  it('should set styles on mouse enter', () => {
    const directive = new Highlight(mockElementRef, mockRenderer);
    directive.highlightColor = 'yellow';
    directive.onEnter();
    expect(mockRenderer.setStyle).toHaveBeenCalledWith(mockElementRef.nativeElement, 'backgroundColor', 'yellow');
  });

  it('should reset styles on mouse leave', () => {
    const directive = new Highlight(mockElementRef, mockRenderer);
    directive.onLeave();
    expect(mockRenderer.removeStyle).toHaveBeenCalledWith(mockElementRef.nativeElement, 'boxShadow');
  });
});
