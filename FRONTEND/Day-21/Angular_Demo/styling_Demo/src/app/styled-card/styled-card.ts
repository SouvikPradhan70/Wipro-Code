import { Component } from '@angular/core';

@Component({
  selector: 'app-styled-card',
  imports: [],
  templateUrl: './styled-card.html',
  styleUrls: ['./styled-card.css'], //external styling 
  styles:[`
    h2 {color:darkblue;}` //inline
  ]
})
export class StyledCard {

}
