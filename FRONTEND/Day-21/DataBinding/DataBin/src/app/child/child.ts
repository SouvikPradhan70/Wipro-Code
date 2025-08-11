import { Component,Input,Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  standalone:true,
  imports: [CommonModule],
  templateUrl: './child.html',
  styleUrls: ['./child.css']
})
export class Child {
  @Input()
  messageFromParrent!: string; //recive data from parent

  @Output() 
  messageToParent =new EventEmitter<string>();

  sendMessage(){
    this.messageToParent .emit("Done mummy and papa!!");
  }

}
