import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import{ Hello } from'./hello/hello';
import { CommonModule } from '@angular/common';

@Component({
  
  selector: 'app-root',
  imports: [RouterOutlet,Hello,FormsModule,CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('testme');
  name="Souvik Pradhan";
  imgUrl="	https://picsum.photos/536/354";

  sayHello(){
    alert("Hello From Angular!!");
  }
  message="";

  isLoggedIn=true;

  users=["Hunny","Souvik","Remo"];

  
}
