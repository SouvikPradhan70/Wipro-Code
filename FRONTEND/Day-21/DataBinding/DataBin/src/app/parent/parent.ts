import { Component } from '@angular/core';
import { Child } from '../child/child';
import {CommonModule} from '@angular/common';

@Component({
  selector: 'app-parent',
  standalone:true,
  imports: [Child,CommonModule],
  templateUrl: './parent.html',
  styleUrls: ['./parent.css']
})
export class Parent {
  message="Hi sweety clean u r house!!!"

  childMessage="";

  reciveMessage(message:string){
    this.childMessage=message;

  }

}
