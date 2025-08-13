import { Component } from '@angular/core';
import { DatePipe, CurrencyPipe, UpperCasePipe, LowerCasePipe, DecimalPipe, PercentPipe, SlicePipe } from '@angular/common';
@Component({
  selector: 'app-pipes',
  imports: [DatePipe, CurrencyPipe, UpperCasePipe, LowerCasePipe, DecimalPipe, PercentPipe, SlicePipe],
  templateUrl: './pipes.html',
  styleUrls: ['./pipes.css']
})
export class Pipes {

  todaysDate=new Date();
  productPrice=1234.56;
  welcomeMessage="Hello Souvik";
  productRating=4.456;
  discount=0.15; //15%
  productName="Laptop";
}
