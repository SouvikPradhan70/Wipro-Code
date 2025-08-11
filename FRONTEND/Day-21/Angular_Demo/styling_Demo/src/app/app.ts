import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StyledCard } from './styled-card/styled-card';
import {ScopeStyling} from './scope-styling/scope-styling';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,StyledCard,ScopeStyling],
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  styles: [`
    .Inline {
      color: red;
      font-size: 20px;
      font-weight: bold;
    }
  `]
})
export class App {
  protected readonly title = signal('styling_Demo');
}
